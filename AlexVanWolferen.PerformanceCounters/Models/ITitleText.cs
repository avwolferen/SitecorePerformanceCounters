using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Models
{
    public interface ITitleText : IModelBase
    {
        string Title { get; set; }

        string Text { get; set; }
    }
}