using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenData.Application.Interface.MED;
using OpenData.Controllers;
using OpenData.Domain.ViewModels.Medicine;
using OpenData.Filters;

namespace OpenData.Areas.Backend.Controllers
{

    [Auth]
    public class AuthController : BaseController
    {
        private IMedicineService medicineService;

        public AuthController(IMedicineService service)
        {
            this.medicineService = service;
        }

        public ActionResult Index()
        {
            var result = medicineService.GetMedicines();
            return View(result);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
 
            if (medicineService.GetMedicine(o => o.PK == id.Value))
            {
                var result = medicineService.GetMedicine(id.Value);
                result.Indications = HttpUtility.HtmlDecode(result.Indications);
                return View(result);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ModelStateExclude]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            else
            {
                var aniMed = medicineService.GetMedicine(id);

                if (TryUpdateModel(aniMed, "", collection.AllKeys, ViewData["Exclude"] as string[]))
                {
                   var result = medicineService.Update(System.Web.HttpContext.Current, aniMed);

                   TempData["ExecuteResult"] = result;
                }

                return RedirectToAction("Index", "Auth", new { area = "Backend" });
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (medicineService.GetMedicine(o => o.PK == id))
            {
                var result = medicineService.Delete(id);
              
                TempData["ExecuteResult"] = result;
                return RedirectToAction("Index", "Auth", new { area="Backend"});
            }  
            else
                return HttpNotFound();              
        }
    }
}