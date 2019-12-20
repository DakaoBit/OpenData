using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenData.Domain.ViewModels.EPA;
using OpenData.Application.Interface;
using OpenData.Application.Services;

namespace OpenData.Controllers
{
    public class EPAController : Controller
    {
        private IAQIService aqiService;

        public EPAController(IAQIService service)
        {
            this.aqiService = service;
        }

        // GET: EPA
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AQI()
        {
            var aqi = aqiService.GetAllSite();
            return View(aqi);
        }

        /// <summary>
        /// 取得單一監測站資料
        /// </summary>
        /// <param name="Site"></param>
        /// <returns></returns>
        public JsonResult GetSite(string SiteId)
        {
           var site = aqiService.GetSite(o => o.SiteId == SiteId);

           return Json(site, JsonRequestBehavior.AllowGet); 
        }

        /// <summary>
        /// 取得全監測站資料
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllSite()
        {
            var sites = aqiService.GetAllSite();
			//aqiService.GetAllSite(o => o.AQI == aqi.AQI);

			return Json(sites, JsonRequestBehavior.AllowGet);
        }

    }
}