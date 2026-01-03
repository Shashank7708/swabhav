using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Play.Common.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Play.Common.MassTransit
{
    public static class Extension
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
             {
                 x.AddConsumers(Assembly.GetEntryAssembly());
                 x.UsingRabbitMq((context, configurator) =>
                 {
                     var configuration = context.GetService<IConfiguration>();
                     var rabbitMQSetting = configuration.GetSection(nameof(RabbitMQSetting)).Get<RabbitMQSetting>();
                     var prefix = configuration.GetValue<string>("ServiceSettings:ServiceName");
                     configurator.Host(rabbitMQSetting.Host);
                     configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(prefix, false));
                     configurator.UseMessageRetry(retryConfigurator =>
                     {
                         retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                     });
                 });
             });
            return services;
        }
    }
}
