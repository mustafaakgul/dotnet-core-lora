using Microsoft.Extensions.DependencyInjection;
using LoRaWAN.RestAccess.Abstract;

namespace LoRaWAN.WebUI.Utilities
{
    public class RestAccessCall
    {
        public static IAccessRest RestAccess { get; set; }
    }

    public static class RestAccessCallExtensions
    {
        public static IAccessRest GetAccessRest(this IServiceCollection service)
        {
            return (IAccessRest)service.BuildServiceProvider().GetService(typeof(IAccessRest));
        }
    }
}