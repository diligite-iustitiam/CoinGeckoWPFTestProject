using CoinGeckoWPFTestProject.Services.Intefraces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ICoinsService, CoinsService>();
            return services;
        }
    }
}
