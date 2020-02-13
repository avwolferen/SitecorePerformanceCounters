using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Models.Maps
{
    public class TitleTextMap : SitecoreGlassMap<ITitleText>
    {
        public override void Configure()
        {
            this.Map(
                x =>
                {
                    x.Id(y => y.Id);
                    this.ImportMap<IModelBase>();
                    x.TemplateId(Templates.TitleText.Id).EnforceTemplateAndBase();
                    x.Field(y => y.Title).FieldId(Templates.TitleText.Fields.Title);
                    x.Field(y => y.Text).FieldId(Templates.TitleText.Fields.Text);
                });
        }
    }
}