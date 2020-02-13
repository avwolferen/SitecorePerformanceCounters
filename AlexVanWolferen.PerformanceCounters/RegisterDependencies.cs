namespace AlexVanWolferen.CustomSitecore.PerformanceCounters
{
    using AlexVanWolferen.CustomSitecore.PerformanceCounters.Extensions;
    using AlexVanWolferen.CustomSitecore.PerformanceCounters.Services;
    using AlexVanWolferen.CustomSitecore.PerformanceCounters.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.DependencyInjection;

    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            if (serviceCollection.IsNullOrEmpty())
            {
                return;
            }

            // Services
            serviceCollection.AddSingleton<ICacheService>(x => new CacheService());
            serviceCollection.AddTransient<IItemService>(x => new ItemService());
            serviceCollection.AddTransient<ILoggingService>(x => new LoggingService());

            // Service container
            serviceCollection.AddTransient<IServiceContainer>(x => new ServiceContainer());
        }
    }
}