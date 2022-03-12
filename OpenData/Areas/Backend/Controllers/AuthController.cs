﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenData.Domain.ViewModels.Medicine;
using OpenData.Filters;

namespace OpenData.Areas.Backend.Controllers
{
    [Auth]
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}