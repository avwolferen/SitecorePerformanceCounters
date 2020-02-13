using Sitecore.Data.Items;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Models
{
    public interface IModelBase
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Url { get; set; }
        Guid TemplateId { get; set; }
        Item Item { get; set; }
        Language Language { get; set; }
        Language OriginalLanguage { get; set; }
        int Version { get; set; }
        string Path { get; set; }
    }
}