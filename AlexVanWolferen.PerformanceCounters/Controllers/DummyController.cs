
using AlexVanWolferen.CustomSitecore.PerformanceCounters.Models;
using AlexVanWolferen.CustomSitecore.PerformanceCounters.Services.Interfaces;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Controllers
{
    public class DummyController : BaseController
    {
        private IServiceContainer services;

        protected DummyController(IServiceContainer services)
        {
            this.services = services;
        }

        protected DummyController()
        {
            this.services  = this.Resolve<IServiceContainer>();
        }

        public ActionResult TitleText()
        {
            var model = this.services.MvcContext.GetDataSourceItem<ITitleText>();
            var sillything = this.services.Cache.GetOrAdd(model.Id.ToString(), () => { return model.Path; });

            return View(model);
        }
    }
}