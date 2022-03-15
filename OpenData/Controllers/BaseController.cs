using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OpenData.Domain.ViewModels.Medicine;
using OpenData.Application.Services.MED;

namespace OpenData.Controllers
{
    public class BaseController : Controller
    {
        #region utility
        /// <summary>
        /// 取得人員資料
        /// </summary>
        /// <returns></returns>
        public static UserDataViewModel GetCurrentLoginUserData()
        {
            UserDataViewModel user;

            HttpRequest Request = System.Web.HttpContext.Current.Request;
            if (Request.IsAuthenticated)
            {
                if (System.Web.HttpContext.Current.User.Identity is FormsIdentity)
                {

                    user = (UserDataViewModel)System.Web.HttpContext.Current.Session["SystemUser"];
                    if (null == user)
                    {
                        AnimalMedService animalMedService = new AnimalMedService();
                        user = animalMedService.UserData(o => o.PK == Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name));

                        System.Web.HttpContext.Current.Session["SystemUser"] = user;
                    }
                }

            }

            return (UserDataViewModel)System.Web.HttpContext.Current.Session["SystemUser"];
        }

        /// <summary>
        /// 辨識使用者從瀏覽器按下 F5 或 Ctrl + R 重新整理頁面
        /// </summary>
        public bool IsRefresh
        {
            get
            {
                return this.Request.Headers["Pragma"] == "no-cache" ||
                       this.Request.Headers["Cache-Control"] == "max-age=0";
            }
        }
        #endregion
    }
}