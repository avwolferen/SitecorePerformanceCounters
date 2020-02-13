using Sitecore.Diagnostics;
using Sitecore.Diagnostics.PerformanceCounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Diagnostics.PerformanceCounters
{
    public static class MyCachingCounters
    {
        public const string CategoryName = "My Custom Cache";

        private const string CacheClearingsName = "Cache Clearings / sec";

        private const string CacheHitsName = "Cache Hits / sec";

        private const string CacheMissesName = "Cache Misses / sec";

        /// <summary>
        /// Gets the counter that counts total number of times that an instance of the eventscache cache has been cleared.
        /// </summary>
        /// <value>
        /// The counter instance.
        /// </value>
        public static AmountPerSecondCounter CacheClearings
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the counter that counts total number of cache hits.
        /// </summary>
        /// <value>
        /// The counter instance.
        /// </value>
        public static AmountPerSecondCounter CacheHits
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the counter that counts total number of cache hits.
        /// </summary>
        /// <value>
        /// The counter instance.
        /// </value>
        public static AmountPerSecondCounter CacheMisses
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes analytics aggregation performance counters.
        /// </summary>
        public static void Initialize()
        {
            Type typeFromHandle = typeof(MyCachingCounters);
            Log.Info(typeFromHandle.FullName + " are initialized", typeFromHandle);
        }

        /// <summary>
        /// Initializes static members of the <see cref="T:Sitecore.Diagnostics.PerformanceCounters.CachingCount" /> class.
        /// </summary>
        static MyCachingCounters()
        {
            try
            {
                CacheClearings = new AmountPerSecondCounter(CacheClearingsName, CategoryName);
                CacheHits = new AmountPerSecondCounter(CacheHitsName, CategoryName);
                CacheMisses = new AmountPerSecondCounter(CacheMissesName, CategoryName);
            }
            catch (Exception)
            {
            }
        }
    }
}