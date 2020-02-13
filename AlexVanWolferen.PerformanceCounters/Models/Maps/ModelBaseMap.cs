using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Models.Maps
{
    public class ModelBaseMap : SitecoreGlassMap<IModelBase>
    {
        public override void Configure()
        {
            this.Map(
                x =>
                {
                    x.Id(y => y.Id);
                    x.Info(y => y.Name).InfoType(SitecoreInfoType.Name);
                    x.Info(y => y.Url).InfoType(SitecoreInfoType.Url);
                    x.Info(y => y.TemplateId).InfoType(SitecoreInfoType.TemplateId);
                    x.Info(y => y.Language).InfoType(SitecoreInfoType.Language);
                    x.Info(y => y.OriginalLanguage).InfoType(SitecoreInfoType.OriginalLanguage);
                    x.Info(y => y.Path).InfoType(SitecoreInfoType.Path);
                    x.Info(y => y.Version).InfoType(SitecoreInfoType.Version);
                    x.Item(y => y.Item);
                });
        }
    }
}