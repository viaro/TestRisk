using Microsoft.Extensions.DependencyInjection;
using RiskSystem.Application;
using RiskSystem.Application.Interfaces;
using RiskSystem.Domain.Factories;
using RiskSystem.Domain.Interfaces;

namespace RiskSystem.Infrastructure
{
    public static class Ioc
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IRiskSystemService, RiskSystemService>();
            services.AddScoped<ITradeFactory, TradeFactory>();
            services.AddScoped<IPortfolioFactory, PortfolioFactory>();

            return services;
        }
    }
}
