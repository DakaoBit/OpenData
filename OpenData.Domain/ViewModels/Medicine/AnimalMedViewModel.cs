using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.Medicine
{
    public class AnimalMedViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 許可證字號 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 動物用藥品中文名稱 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 動物用藥品英文名稱 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 業者名稱 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 業者地址 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 製造廠名稱 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 製造廠地址 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 劑型 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 包裝 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 效能適應症 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 成分 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 核發日期 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 有效期間 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 外銷專用 { get; set; }
    }
}
