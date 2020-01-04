using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.PTX
{
	public class Air_AirlineViewModel
	{
		[Display(Name = "航空公司IATA國際代碼")]
		public string AirlineID { get; set; }
		[Display(Name = "航空公司")]
		public Airlinename AirlineName { get; set; }
		[Display(Name = "航空公司")]
		public Airlinenamealias AirlineNameAlias { get; set; }
		[Display(Name = "航空公司IATA國際代碼")]
		public string AirlineIATA { get; set; }
		[Display(Name = "航空公司ICAO國際代碼")]
		public string AirlineICAO { get; set; }
		[Display(Name = "航空公司電子信箱")]
		public string AirlineEmail { get; set; }
		[Display(Name = "航空公司地址")]
		public string AirlineAddress { get; set; }
		[Display(Name = "航空公司聯繫電話")]
		public string AirlinePhone { get; set; }
		[Display(Name = "航空公司國籍 ")]
		public string AirlineNationality { get; set; }
		[Display(Name = "資料更新時間")]
		public string UpdateTime { get; set; }
		[Display(Name = "資料版本編號")]
		public int VersionID { get; set; }
	}
 
	public class Airlinename
	{
		[Display(Name = "中文名")]
		public string Zh_tw { get; set; }
		[Display(Name = "英文名")]
		public string En { get; set; }
	}

	public class Airlinenamealias
	{
		[Display(Name = "中文名")]
		public string Zh_tw { get; set; }
		[Display(Name = "英文名")]
		public string En { get; set; }
	}

}
