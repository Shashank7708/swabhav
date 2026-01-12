using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RestaurantTableBookingApp;
using RestaurantTableBookingApp.Data;
using RestaurantTableBookingApp.Data.Interfaces;
using RestaurantTableBookingApp.Service.Interface;
using Scalar.AspNetCore;
using Serilog;
using System.Net;

//Serilog
Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    //Serilog
    builder.Services.AddApplicationInsightsTelemetry();
    builder.Host.UseSerilog((context, services, loggerConfiguration) => loggerConfiguration
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(
                  services.GetRequiredService<TelemetryConfiguration>(),
                  TelemetryConverter.Events));

    Log.Information("Starting the application...");


    // Add services to the container.
    var configuration = builder.Configuration;
    builder.Services.AddDbContext<RestaurantTableBookingDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DbContext") ?? "")
    .EnableSensitiveDataLogging()); //This is used to log any sql server issue... to be used for local not for productions

    builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    builder.Services.AddScoped<IRestaurantService, RestaurantService>();
    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddOpenApi("v1");

    var app = builder.Build();

    //Exception handling. Create a middleware and include that here
    //Enable Serilog exception logging
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            Log.Error(exception, "Unhandled exception occurred. {ExceptionDetails}", exception?.ToString());

            Console.WriteLine(exception?.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
        });
    });



    //Middleware
    app.UseMiddleware<RequestResponseLoggingMiddleware>();


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }
    else 
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}