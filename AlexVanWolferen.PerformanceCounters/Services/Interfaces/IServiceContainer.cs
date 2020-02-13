using Glass.Mapper.Sc.Web.Mvc;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Services.Interfaces
{
    public interface IServiceContainer
    {
        ILoggingService Logging { get; }

        IItemService Items { get; }

        ICacheService Cache { get; }

        IMvcContext MvcContext { get; }
    }
}