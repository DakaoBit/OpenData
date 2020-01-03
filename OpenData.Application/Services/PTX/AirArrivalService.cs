using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpenData.Application.Interface.PTX;
using OpenData.Domain.ViewModels.PTX;
using RestSharp;
using Newtonsoft.Json;
using OpenData.Application.Services.Security;

namespace OpenData.Application.Services.PTX
{
	public class AirArrivalService : IAirArrivalService
	{
		//API Url
		private static string url_AirApi_Airport = "https://ptx.transportdata.tw/MOTC/v2/Air/Airport?$format=JSON";
		private static string url_AirApi_Arrival = "https://ptx.transportdata.tw/MOTC/v2/Air/FIDS/Airport/Arrival?$format=JSON";
		//APP ID
		private const string APPID = "5eb5d7520a0f41369acf54ea492db156";
		//APP Key
		private const string APPKey = "U8A6eWVcYFLIFkXvNKdbBnVhMQQ";

		//簽章使用
		string xdate; //UTC date
		string SignDate;  //Sign date
		string Signature;
		string sAuth;

		private RestClient client;
		private RestRequest request;
		private IRestResponse response;

		public AirArrivalService()
		{
			//啟用 TLS 1.2
			System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

			//取得當下UTC時間
			xdate = DateTime.Now.ToUniversalTime().ToString("r");
		    SignDate = "x-date: " + xdate;
 
			//取得加密簽章
		    Signature = HMAC_SHA1.Signature(SignDate, APPKey);
		    sAuth = "hmac username=\"" + APPID + "\", algorithm=\"hmac-sha1\", headers=\"x-date\", signature=\"" + Signature + "\"";
			
			#region 官方 提供方式
			//
			//using (HttpClient Client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
			//{
			//	Client.DefaultRequestHeaders.Add("Authorization", sAuth);
			//	Client.DefaultRequestHeaders.Add("x-date", xdate);
			//	Result = Client.GetStringAsync(url_AirApi_Arrival).Result;
			//}
			#endregion
		}

		public List<Air_AriportViewModel> GetAllAirport()
		{
			this.client = new RestClient(url_AirApi_Airport);
			client.AddDefaultHeader("Authorization", sAuth);
			client.AddDefaultHeader("x-date", xdate);
			this.request = new RestRequest(Method.GET);

			this.response = client.Execute(request);

			var data = JsonConvert.DeserializeObject<IEnumerable<Air_AriportViewModel>>(response.Content);

			return data.ToList();
		}

		public List<Air_ArrivalViewModel> GetAllArrival()
		{
			this.client = new RestClient(url_AirApi_Arrival);
			client.AddDefaultHeader("Authorization", sAuth);
			client.AddDefaultHeader("x-date", xdate);
			this.request = new RestRequest(Method.GET);

			this.response = client.Execute(request);

			var airArrival =
			JsonConvert.DeserializeObject<IEnumerable<Air_ArrivalViewModel>>(response.Content);

			return airArrival.ToList();
		}
	}
}
