using AlexVanWolferen.CustomSitecore.PerformanceCounters.Diagnostics.PerformanceCounters;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Pipelines.Loader
{
    public class InitializePerformanceCounters
    {
        public void Process(PipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            MyCachingCounters.Initialize();
        }
    }
}