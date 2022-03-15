using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OpenData.Application.Interface.MED;
using OpenData.CustomResults;
using OpenData.Domain.ViewModels.Medicine;

namespace OpenData.Controllers
{
    /// <summary>
    ///  衛生福利部食品藥物管理署 - 動物用藥資訊
    /// </summary>
    public class MedicineController : BaseController
    {
        private IMedicineService medicineService;

        public MedicineController(IMedicineService service)
        {
            this.medicineService = service;
        }

        // GET: Medicine
        public ActionResult Index()
        {
           var result = medicineService.GetMedicines();
            return View(result);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = medicineService.GetMedicine(id.Value);
           
            if (result == null)
               return HttpNotFound();
            else
               return View(result);
        }

        public ActionResult ConverterToDB()
        {
            medicineService.AddMedicine(LoadJson().Take(60));
            return Content("1");
        }

        [HttpGet]
        public ActionResult Show()
        {
            //return new JsonResult()
            //{
            //    Data = LoadJson().Take(30),
            //    MaxJsonLength = int.MaxValue,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};

            var Data = LoadJson();
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.Formatting = Formatting.Indented;
            jsonNetResult.Data = Data;

            return jsonNetResult;
        }

        public ActionResult InfiniteResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowAllData(int pageNumber, int pageSize)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.Formatting = Formatting.Indented;
            try
            {
                pageNumber = pageNumber - 1;

                var Data = LoadJson().Skip(pageNumber * pageSize).Take(pageSize).ToList();
                bool NoMoreData = false;

                if (Data.Count() <= 0)
                {
                    NoMoreData = true;
                }

                jsonNetResult.Data = new {
                    IsSuccess = true,
                    Data = Data,
                    NoMoreData = NoMoreData,
                };
            }
            catch (Exception ex)
            {
                jsonNetResult.Data = new
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
 
            return jsonNetResult;
        }

        public List<ChAnimalMedViewModel> LoadJson()
        {
            var list = new List<ChAnimalMedViewModel>();

            string json = "";
            string filePath = Server.MapPath("~/App_Data/AnimalMedicine.json");

            using (StreamReader r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<ChAnimalMedViewModel>>(json);
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

            var result = medicineService.LoginAuth(System.Web.HttpContext.Current, viewModel);
            TempData["ExecuteResult"] = result;

            if (result.isSuccess)
                return RedirectToAction("Index", "Auth", new { area = "Backend"});
            else
                return View(viewModel);
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

            var result = medicineService.Register(viewModel);
            TempData["ExecuteResult"] = result;

            if (result.isSuccess)
                return RedirectToAction("Login", "Medicine", new { area = "" });
            else
                return View(viewModel);
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Index", "Medicine", new { area = "" });
        }
    }
}