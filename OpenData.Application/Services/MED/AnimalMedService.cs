using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenData.Application.Interface.MED;
using OpenData.Domain.ViewModels.Medicine;
using OpenData.Domain;

namespace OpenData.Application.Services.MED
{
    public class AnimalMedService : IMedicineService, IDisposable
    {
        private OpenDataEntities db;

        public AnimalMedService()
        {
            db = new OpenDataEntities();
        }

        public void AddMedicine(IEnumerable<AnimalMedViewModel> viewModel) 
        {
            bool IsExport = false;
            foreach (var item in viewModel)
            {
                switch (item.外銷專用)
                {
                    case "是":
                        IsExport = true;
                        break;

                    case "否":
                        IsExport = false;
                        break;
                }

                var animalM = new XT_AnimalMedicine
                {
                    LicenseNum = item.許可證字號,
                    ChName = item.動物用藥品中文名稱,
                    EnName = item.動物用藥品英文名稱,
                    CompanyName = item.業者名稱,
                    CompanyAddress = item.業者地址,
                    FactoryName = item.製造廠名稱,
                    FactoryAddress = item.製造廠地址,
                    DosageForm = item.劑型,
                    Package = item.包裝,
                    Indications = item.效能適應症,
                    Element = item.成分,
                    IssueDate = item.核發日期,
                    ValidPeriod = item.有效期間,
                    ForExport = IsExport,
                    CreateUser = "Admin",
                    CreateDate = DateTime.Now
                };

                try
                {
                    db.XT_AnimalMedicine.Add(animalM);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {

                    throw ex;
                }
            }

           
        }

        public AnimalMedViewModel GetMedicine(Func<AnimalMedViewModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<AnimalMedViewModel> GetMedicines()
        {
            throw new NotImplementedException();
        }

        public List<AnimalMedViewModel> GetMedicines(Func<AnimalMedViewModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~AnimalMedService() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
