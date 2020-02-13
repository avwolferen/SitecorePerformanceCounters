using Sitecore.DependencyInjection;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Controllers
{
    public class BaseController : SitecoreController
    {
        protected T Resolve<T>()
            where T : class
        {
            return ServiceLocator.ServiceProvider.GetService(typeof(T)) as T;
        }
    }
}