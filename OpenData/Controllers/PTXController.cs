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

		/// <summary>
		/// 取得指定機場的入境航班
		/// </summary>
		/// <param name="IATA">IATA 機場代碼</param>
		/// <returns></returns>
		public ActionResult AirArrival(string IATA)
		{
			Dictionary<string, string> IATA_Airport = new Dictionary<string, string>();
			IATA_Airport.Add("RMQ", "臺中國際機場");
			IATA_Airport.Add("TNN", "臺南機場");
			IATA_Airport.Add("MZG", "澎湖");
			IATA_Airport.Add("KNH", "金門機場");
			IATA_Airport.Add("KHH", "高雄小港國際機場");
			IATA_Airport.Add("TTT", "臺東機場");
			IATA_Airport.Add("TPE", "臺北桃園國際機場");
			IATA_Airport.Add("HUN", "花蓮機場	");
			IATA_Airport.Add("PIF", "屏東");
			IATA_Airport.Add("MFK", "馬祖北竿機場");

			var airArrival = airArrivalService.GetAllArrival(IATA);
			ViewBag.airport = IATA_Airport[IATA];
			return View(airArrival);
		}


	}
}