using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenData.Application.Interface.MED;

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

       
    }
}