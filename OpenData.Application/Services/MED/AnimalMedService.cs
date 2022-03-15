using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenData.Application.Interface.MED;
using OpenData.Domain.ViewModels.Medicine;
using OpenData.Domain;
using System.Web;
using AutoMapper;
using System.Linq.Expressions;
using Microsoft.Security.Application;

namespace OpenData.Application.Services.MED
{
    public class AnimalMedService : IMedicineService, IDisposable
    {
        private OpenDataEntities db;
        private ExecuteResultModel result;

        public AnimalMedService()
        {
            db = new OpenDataEntities();
            result = new ExecuteResultModel();
        }

        public void AddMedicine(IEnumerable<ChAnimalMedViewModel> viewModel)
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

        public AnimalMedViewModel GetMedicine(int id)
        {
            var aniMed = db.XT_AnimalMedicine.Find(id);

            var config = new MapperConfiguration(cfg =>
          cfg.CreateMap<XT_AnimalMedicine, AnimalMedViewModel>());

            var mapper = new Mapper(config);
            return mapper.Map<AnimalMedViewModel>(aniMed);
        }

        public bool GetMedicine(Func<XT_AnimalMedicine, bool> filter)
        {
            return db.XT_AnimalMedicine.Where(filter).Any();
        }

        public List<AnimalMedViewModel> GetMedicines()
        {
            var list = db.XT_AnimalMedicine.ToList();

            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<XT_AnimalMedicine, AnimalMedViewModel>());

            var mapper = new Mapper(config);
            return mapper.Map<List<AnimalMedViewModel>>(list);
        }

        public List<AnimalMedViewModel> GetMedicines(Func<AnimalMedViewModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public ExecuteResultModel Update(HttpContext context, AnimalMedViewModel viewModel)
        {
            UserDataViewModel user = (UserDataViewModel)context.Session["SystemUser"];
            int status = 0;
            XT_AnimalMedicine aniMed = db.XT_AnimalMedicine.Find(viewModel.PK);
            aniMed.Indications = Sanitizer.GetSafeHtmlFragment(viewModel.Indications);
            aniMed.EditUser = user.UserID;
            aniMed.EditDate = DateTime.Now;

            try
            {
                status = db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw ex;
            }

            if (status > 0)
            {
                result.isSuccess = true;
                result.message.Add(string.Format("品名: {0} 編輯成功!", viewModel.ChName));
            }
            else
            {
                result.isSuccess = false;
                result.message.Add("編輯失敗");
            }

            return result;
        }

        public ExecuteResultModel Delete(int id)
        {
            var aniMed = db.XT_AnimalMedicine.Find(id);

            try
            {
                db.XT_AnimalMedicine.Remove(aniMed);
                db.SaveChanges();

                result.isSuccess = true;
                result.message.Add("刪除成功!");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                result.isSuccess = false;
                result.message.Add(String.Format("Error: {0}, {1}", ex.Message, ex.StackTrace));
                throw ex;
            }

            return result;
        }

        #region Login
        public UserDataViewModel UserData(Func<XT_User, bool> filter)
        {
           var user = db.XT_User.Where(filter).FirstOrDefault();
           var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<XT_User, UserDataViewModel>()
             );

           var mapper = new Mapper(config);
           return mapper.Map<UserDataViewModel>(user);
        }

        public ExecuteResultModel LoginAuth(HttpContext context, LoginViewModel viewModel)
        {
            var user = db.XT_User
                 .Where(o => o.UserID == viewModel.UserID)
                 .Where(o => o.Password == viewModel.Password)
                 .FirstOrDefault();

            if (null == user)
            {
                var pUser = db.XT_User
               .Where(o => o.UserID == viewModel.UserID.Trim())
               .FirstOrDefault();

                if (null != pUser)
                {
                    result.isSuccess = false;
                    result.message.Add("密碼錯誤!");
                }
                else
                {
                    result.isSuccess = false;
                    result.message.Add("無此帳號，請重新登入!");
                }
                return result;
            }
            else
            {
                context.Session["SystemUser"] =  UserData(o => o.PK == user.PK);
                context.Session["UserName"] = UserData(o => o.PK == user.PK).Name;
                result.isSuccess = true;
                result.message.Add("歡迎登入!");
                return result;
            }
        }
        #endregion

        #region Register
        public ExecuteResultModel Register(UserRegisterViewModel viewModel)
        {
            int status = 0;
            if (IsUserID(viewModel.UserID))
            {
                result.isSuccess = false;
                result.message.Add("該帳號已有人使用");

                return result;
            }
            else
            {
                var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<UserRegisterViewModel, XT_User>()
                );

                var mapper = new Mapper(config);
                var user = mapper.Map<XT_User>(viewModel);

                try
                {
                    db.XT_User.Add(user);
                    status = db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    result.isSuccess = false;
                    result.message.Add(String.Format("Error: {0}, {1}", ex.Message, ex.StackTrace));
                    throw ex;
                }

                if (status > 0)
                {
                    result.isSuccess = true;
                    result.message.Add("註冊成功");
                    result.message.Add("請重新登入");
                    return result;
                }
                else
                {
                    result.isSuccess = false;
                    result.message.Add("新增失敗");
                    return result;
                }
            }
        }

        public bool IsUserID(string userid)
        {
            return db.XT_User.Where(o => o.UserID == userid).Any();
        }


        #endregion

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
