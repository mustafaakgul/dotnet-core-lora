using LoRaWAN.Data.Dals.Abstract;
using LoRaWAN.Data.Dals.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoRaWAN.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatalayerModule(this IServiceCollection services)
        {
            services.AddScoped<IEndNodeRepository, EndNodeRepository>();
            services.AddScoped<IGatewayRepository, GatewayRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IManagementUserRepository, ManagementUserRepository>();

            return services;
        }
    }
}
