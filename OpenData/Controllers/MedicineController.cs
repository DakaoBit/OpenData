using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OpenData.Application.Interface.MED;
using OpenData.Domain.ViewModels.Medicine;

namespace OpenData.Controllers
{
    /// <summary>
    ///  衛生福利部食品藥物管理署 - 動物用藥資訊
    /// </summary>
    public class MedicineController : Controller
    {
        private IMedicineService medicineService;

        public MedicineController(IMedicineService service)
        {
            this.medicineService = service;
        }

        // GET: Medicine
        public ActionResult Index()
        {
           //var med = medicineService.GetMedicines();

            return View();
        }

        public ActionResult ConverterToDB()
        {
            //medicineService.AddMedicine(LoadJson().Take(30));
            return Content("1");
        }

        [HttpGet]
        public JsonResult Show()
        {
            return new JsonResult()
            {
                Data = LoadJson().Take(30),
                MaxJsonLength = int.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public List<AnimalMedViewModel> LoadJson()
        {
            var list = new List<AnimalMedViewModel>();

            string json = "";
            string filePath = Server.MapPath("~/App_Data/AnimalMedicine.json");

            using (StreamReader r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<AnimalMedViewModel>>(json);
            }
  
            return list;
        }

        public ActionResult Login()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (viewModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (!ModelState.IsValid)
                return View(viewModel);

            //未完成
            return View();
        }


        public ActionResult Register()
        {
            UserRegisterViewModel register = new UserRegisterViewModel();
            return View(register);
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel viewModel)
        {
            if (viewModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (!ModelState.IsValid)
                return View(viewModel);

            //未完成
            return View();
        }
    }
}