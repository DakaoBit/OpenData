using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpenData.Application.Interface;
using OpenData.Domain.ViewModels.EPA;
using RestSharp;
using Newtonsoft.Json;

namespace OpenData.Application.Services
{
    public class AQIService : IAQIService
    {
        private static string AQI_url = "http://opendata2.epa.gov.tw/AQI.json";
        private readonly RestClient client;
        private readonly RestRequest request;
        private readonly IRestResponse response;

        public AQIService()
        {
            this.client = new RestClient(AQI_url);
            this.request = new RestRequest(Method.GET);
            this.response = client.Execute(request);
        }

        public AQIViewModel GetSite(Func<AQIViewModel, bool> filter)
        {
            var aqi = JsonConvert.DeserializeObject<IEnumerable<AQIViewModel>>(response.Content);

            return aqi.Where(filter).FirstOrDefault();
        }

        public List<AQIViewModel> GetAllSite()
        {
            var aqi = JsonConvert.DeserializeObject<IEnumerable<AQIViewModel>>(response.Content);

            return aqi.ToList();
        }

        public List<AQIViewModel> GetAllSite(Func<AQIViewModel, bool> filter)
        {
            var aqi = JsonConvert.DeserializeObject<IEnumerable<AQIViewModel>>(response.Content);

            return aqi.Where(filter).ToList();
        }

        public List<SelectListItem> GetCountyOption()
        {
            var aqi = JsonConvert.DeserializeObject<IEnumerable<AQIViewModel>>(response.Content);

            var county = aqi
                .GroupBy(o => new { countyName = o.County })
                .Select(c => c.Key.countyName).ToList();

            var countyOptions = new List<SelectListItem>();
            countyOptions.AddRange(county.ConvertAll(o => {
                return new SelectListItem()
                {
                    Text = o.ToString(),
                    Value = o.ToString()
                };
            }));

            return countyOptions;
        }

       
    }
}
