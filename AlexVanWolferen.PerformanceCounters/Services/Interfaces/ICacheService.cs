using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Services.Interfaces
{
    public interface ICacheService
    {
        TCachedObject GetOrAdd<TCachedObject>(string key, Func<TCachedObject> func);
    }
}