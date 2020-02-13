namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Services
{
    using AlexVanWolferen.CustomSitecore.PerformanceCounters.Services.Interfaces;
    using Glass.Mapper.Sc.Web.Mvc;
    using Sitecore.DependencyInjection;

    public class ServiceContainer : IServiceContainer
    {
        private ILoggingService logging;

        private IItemService items;

        private ICacheService cache;

        private IMvcContext mvcContext;

        public ILoggingService Logging
        {
            get
            {
                return this.logging ?? (this.logging = this.Resolve<ILoggingService>());
            }

            set
            {
                this.logging = value;
            }
        }

        public IItemService Items
        {
            get
            {
                return this.items ?? (this.items = this.Resolve<IItemService>());
            }

            set
            {
                this.items = value;
            }
        }

        public ICacheService Cache
        {
            get
            {
                return this.cache ?? (this.cache = this.Resolve<ICacheService>());
            }

            set
            {
                this.cache = value;
            }
        }

        public IMvcContext MvcContext
        {
            get
            {
                return this.mvcContext ?? (this.mvcContext = new MvcContext());
            }

            set
            {
                this.mvcContext = value;
            }
        }

        private T Resolve<T>()
            where T : class
        {
            return ServiceLocator.ServiceProvider.GetService(typeof(T)) as T;
        }
    }
}