using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.PTX
{
	public class Air_AriportViewModel
	{
		[Display(Name = "機場IATA國際代碼")]
		public string AirportID { get; set; }

		[JsonProperty("Airportname")]
		[Display(Name = "機場中文名稱")]
		public Airportname AirportName { get; set; }

		[Display(Name = "機場IATA國際代碼")]
		public string AirportIATA { get; set; }
		[Display(Name = "機場ICAO國際代碼")]
		public string AirportICAO { get; set; }

		[JsonProperty("Airportposition")]
		[Display(Name = "機場位置")]
		public Airportposition AirportPosition { get; set; }

		[JsonProperty("Airportcityname")]
		[Display(Name = "機場所屬城市")]
		public Airportcityname AirportCityName { get; set; }

		[Display(Name = "機場地址")]
		public string AirportAdrress { get; set; }
		[Display(Name = "機場聯繫電話")]
		public string AirportPhone { get; set; }
		[Display(Name = "機場國籍")]
		public string AirportNationality { get; set; }
		[Display(Name = " 業務機關代碼")]
		public string AuthorityID { get; set; }
		[Display(Name = " 資料更新時間")]
		public string UpdateTime { get; set; }
		[Display(Name = " 資料版本編號")]
		public int VersionID { get; set; }
	}

	public class Airportname
	{
		[Display(Name = "中文名")]
		public string Zh_tw { get; set; }
		[Display(Name = "英文名")]
		public string En { get; set; }
	}

	public class Airportposition
	{
		[Display(Name = "緯度")]
		public string PositionLat { get; set; }
		[Display(Name = "經度")]
		public string PositionLon { get; set; }
	}

	public class Airportcityname
	{
		[Display(Name = "中文名")]
		public string Zh_tw { get; set; }
		[Display(Name = "英文名")]
		public string En { get; set; }
	}
 
}
