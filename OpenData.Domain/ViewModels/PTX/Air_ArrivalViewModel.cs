using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.PTX
{
	public class Air_ArrivalViewModel
	{
		
		[Display(Name = "航班日期")] 
		public string FlightDate { get; set; }
		//(ISO8601格式:yyyy-MM-dd)

		[Display(Name = "航機班號")]
		public string FlightNumber { get; set; }

		[Display(Name = "航線種類")]
		public int AirRouteType { get; set; }
		//(目前民航局與桃機的FIDS系統都尚未提供此欄位資料) 
		//[-2:'特殊',1:'國際',2:'國內',3:'兩岸',4:'國際包機',5:'國內包機',6:'兩岸包機'] 

		[Display(Name = "航空公司IATA國際代碼")]
		public string AirlineID { get; set; }

		[Display(Name = "起點機場IATA國際代碼")]
		public string DepartureAirportID { get; set; }

		[Display(Name = "目的地機場IATA國際代碼")]
		public string ArrivalAirportID { get; set; }

		[Display(Name = "表訂抵達時間")]
		public string ScheduleArrivalTime { get; set; }
		//(ISO8601格式:yyyy-MM-ddTHH:mm) 

		[Display(Name = "實際抵達時間")]
		public string ActualArrivalTime { get; set; }
		//(ISO8601格式:yyyy-MM-ddTHH:mm)

		[Display(Name = "預估抵達時間")]
		public string EstimatedArrivalTime { get; set; }
		//(ISO8601格式:yyyy-MM-ddTHH:mm)

		[Display(Name = "航班屬性狀態")]
		public string ArrivalRemark { get; set; }
		//航班屬性狀態,為該機場觀點的狀態

		[JsonProperty(PropertyName = "ArrivalRemarkEn")]
		[Display(Name = "航班屬性狀態(英)")]
		public string ArrivalRemarkEn { get; set; }
		//航班屬性狀態,為該機場觀點的狀態(英)

		[Display(Name = "航廈")]
		public string Terminal { get; set; }

		[Display(Name = "登機門")]
		public string Gate { get; set; }

		[Display(Name = "航班共用班號")]
		public string CodeShare { get; set; }

		[Display(Name = "是否為貨機")]
		public bool ㄏ { get; set; }

		[Display(Name = "航空器型號")]
		public string AcType { get; set; }

		[JsonProperty(PropertyName = "BaggageClaim")]
		[Display(Name = "行李轉盤")]
		public string BaggageClaim { get; set; }
		//(到站FIDS可能有「行李轉盤」資訊, 離站FIDS不會有)

		[JsonProperty(PropertyName = "CheckCounter")]
		[Display(Name = "報到櫃檯")]
		public string CheckCounter { get; set; }
		//(到站FIDS不會有「報到櫃台」資訊, 離站FIDS才可能有) ,

		[Display(Name = "資料更新日期時間")]
		public string UpdateTime { get; set; }
		//(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
		 

	}
}
