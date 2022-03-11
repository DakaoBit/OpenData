using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.Medicine
{
    public class AnimalMedViewModel
    {
        public string 許可證字號 { get; set; }
        public string 動物用藥品中文名稱 { get; set; }
        public string 動物用藥品英文名稱 { get; set; }
        public string 業者名稱 { get; set; }
        public string 業者地址 { get; set; }
        public string 製造廠名稱 { get; set; }
        public string 製造廠地址 { get; set; }
        public string 劑型 { get; set; }
        public string 包裝 { get; set; }
        public string 效能適應症 { get; set; }
        public string 成分 { get; set; }
        public string 核發日期 { get; set; }
        public string 有效期間 { get; set; }
        public string 外銷專用 { get; set; }
    }
}
