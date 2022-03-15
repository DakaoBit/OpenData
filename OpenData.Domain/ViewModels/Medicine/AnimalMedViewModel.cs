using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenData.Domain.ViewModels.Medicine
{
    public class AnimalMedViewModel
    {
        public int PK { get; set; }

        [Display(Name = "許可證字號")]
        //許可證字號
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LicenseNum { get; set; }

        [Display(Name = "動物用藥品中文名稱")]
        //動物用藥品中文名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChName { get; set; }

        [Display(Name = "動物用藥品英文名稱")]
        //動物用藥品英文名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EnName { get; set; }

        [Display(Name = "業者名稱")]
        //業者名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [Display(Name = "業者地址")]
        //業者地址
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyAddress { get; set; }

        [Display(Name = "製造廠名稱")]
        //製造廠名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FactoryName { get; set; }

        [Display(Name = "製造廠地址")]
        //製造廠地址
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FactoryAddress { get; set; }

        [Display(Name = "劑型")]
        //劑型
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DosageForm { get; set; }

        [Display(Name = "包裝")]
        //包裝
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Package { get; set; }

        [Display(Name = "效能適應症")]
        [AllowHtml]
        //效能適應症
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Indications { get; set; }

        [Display(Name = "成分")]
        //成分
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Element { get; set; }

        [Display(Name = "核發日期")]
        //核發日期
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IssueDate { get; set; }

        [Display(Name = "有效期間")]
        //有效期間
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ValidPeriod { get; set; }

        [Display(Name = "外銷專用")]
        //外銷專用
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ForExport { get; set; }

        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }

        public string EditUser { get; set; }
        public DateTime EditDate { get; set; }
    }

    public class ChAnimalMedViewModel {
        //許可證字號
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 許可證字號 { get; set; }

        //動物用藥品中文名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 動物用藥品中文名稱 { get; set; }

        //動物用藥品英文名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 動物用藥品英文名稱 { get; set; }

        //業者名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 業者名稱 { get; set; }

        //業者地址
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 業者地址 { get; set; }

        //製造廠名稱
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 製造廠名稱 { get; set; }

        //製造廠地址
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 製造廠地址 { get; set; }

        //劑型
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 劑型 { get; set; }

        //包裝
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 包裝 { get; set; }

        //效能適應症
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 效能適應症 { get; set; }

        //成分
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 成分 { get; set; }

        //核發日期
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 核發日期 { get; set; }

        //有效期間
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 有效期間 { get; set; }

        //外銷專用
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string 外銷專用 { get; set; }
    }
}
