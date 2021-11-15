using LoRaWAN.Business.Abstract;
using LoRaWAN.Business.Concrete;
using LoRaWAN.Data.Context;
using LoRaWAN.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoRaWAN.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessModule(this IServiceCollection services)
        {
            services.AddScoped<IEndNodeService, EndNodeService>();
            services.AddScoped<IGatewayService, GatewayService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IManagementUserService, ManagementUserService>();
            services.AddScoped<ILoginService, LoginService>();      

            //services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
