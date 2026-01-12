using Microsoft.Extensions.Logging;
using Play.Common.MassTransit;
using Play.Common.MongoDB;
using Play.Inventory.Service.Clients;
using Play.Inventory.Service.Entities;
using Polly;
using Polly.Timeout;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMongo()
    .AddMongoRepository<InventoryItem>("inventory")
    .AddMongoRepository<CatalogItem>("catalogItems")
    .AddMassTransitWithRabbitMq();





Random jitter=new Random();
 

builder.Services.AddHttpClient<CatalogClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7058");
})
.AddTransientHttpErrorPolicy(retry => retry.Or<TimeoutRejectedException>().WaitAndRetryAsync
(
    5,                                                                  //How Many Retry
    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))  //2 muliple between time interval eg after 1sec,2sec,4 sec
    //If 2 or more service are calling CatalogClient exactly after 1sec, 2sec, 4 sec, it may cause burst on the CataLogItem.Service, to avoid that we will use randomness ..to avoid temporal glitches
                    +TimeSpan.FromMilliseconds(jitter.Next(0,1000)),
    //Below code is just for logging purpose
    onRetry:(outcome,timespan, retryAttempt) =>
    {

        var serviceProvider = builder.Services.BuildServiceProvider();
        serviceProvider.GetService<ILogger<CatalogClient>>()?.LogWarning($" Delaying for {timespan.TotalSeconds}, then making retry {retryAttempt}");
    })
)   //retry between interval
.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.Or<TimeoutRejectedException>().CircuitBreakerAsync
(
    3,  //Circuit Breaker after 3 reqeuest
    TimeSpan.FromSeconds(15), //After circuit break occurs, check after 15 sec
    onBreak: (outcome, timespan) =>
    {

        var serviceProvider = builder.Services.BuildServiceProvider();
        serviceProvider.GetService<ILogger<CatalogClient>>()?.LogWarning($"Opening Circuit for{timespan.TotalSeconds} seconds..");

    },
    onReset: () =>
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        serviceProvider.GetService<ILogger<CatalogClient>>()?.LogWarning($"Closing the Circuit");
    }
))
.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));








// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
