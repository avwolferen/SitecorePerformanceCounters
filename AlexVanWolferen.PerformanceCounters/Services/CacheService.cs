using AlexVanWolferen.CustomSitecore.PerformanceCounters.Diagnostics.PerformanceCounters;
using Sitecore.Caching;
using System;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Services
{
    public class CacheService : Interfaces.ICacheService
    {
        static readonly Cache sitelockCache = new Cache("MyCustomCache.Cache", Sitecore.Configuration.Settings.GetSetting("MyCustomCache.CacheSize", "10MB"));

        public CacheService()
        {
            Sitecore.Events.Event.Subscribe("publish:end", ClearCache_OnPublishEnd);
            Sitecore.Events.Event.Subscribe("publish:end:remote", ClearCache_OnPublishEnd);
        }

        private void ClearCache_OnPublishEnd(object sender, System.EventArgs eventArgs)
        {
            sitelockCache.Clear();
            MyCachingCounters.CacheClearings.Increment();
        }

        public TCachedObject GetOrAdd<TCachedObject>(string key, Func<TCachedObject> getFunky)
        {
            if (sitelockCache == null)
            {
                return default(TCachedObject);
            }

            var cachekey = $"{nameof(TCachedObject)}_{key}";
            TCachedObject value = default(TCachedObject);
            value = (TCachedObject)sitelockCache.GetValue(cachekey);

            if (value == null)
            {
                value = getFunky();
                sitelockCache.Add(cachekey, value);
                MyCachingCounters.CacheMisses.Increment();
            }
            else
            {
                MyCachingCounters.CacheHits.Increment();
            }

            return value;
        }
    }

}