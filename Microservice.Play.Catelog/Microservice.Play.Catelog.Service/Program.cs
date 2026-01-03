using MassTransit;
using Microservice.Play.Catelog;
using Play.Common.MassTransit;
using Play.Common.MongoDB;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//Play.Common Source
builder.Services.AddMongo()
    .AddMongoRepository<Item>("items")
.AddMassTransitWithRabbitMq();

//builder.Services.AddMassTransitHostedService(); //Not needed for MassTransit v8 or later

builder.Services.AddControllers(options=>
{ options.SuppressAsyncSuffixInActionNames = false; }); //If an actionmethod has Async in suffix eg GetByIdAsync and we are calling CreatedOnAction and passing this method, it will remove async, to prevent it, we add this line
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
