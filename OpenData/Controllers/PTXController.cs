using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenData.Application.Interface.PTX;
 
namespace OpenData.Controllers
{
	/// <summary>
	/// 交通部 - 公共運輸整合資訊流通平台( Public Transport Data eXchange，PTX ) 
	/// </summary>
	public class PTXController : Controller
	{
		private IAirArrivalService airArrivalService;
		 
		public PTXController(IAirArrivalService service)
		{
			this.airArrivalService = service;
		}

		// GET: PTX
		public ActionResult Index()
		{
			return View(); 
		}

		public ActionResult Airport()
		{
			//台灣機場
			string[] twAirport = { "TPE", "HSZ", "RMQ", "TNN", "KHH",
			"PIF", "TTT", "HUN", "MZG", "KNH", "MFK", "LZN" };

			var airport = airArrivalService.GetAllAirport()
							.Where(o => twAirport.Contains(o.AirportID));

			return View(airport);
		}

		public JsonResult AirArrival(string IATA)
		{
			var airArrival = airArrivalService.GetAllArrival(IATA);
		 
			return Json(airArrival, JsonRequestBehavior.AllowGet);
		}


	}
}