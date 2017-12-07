﻿using BusinessLogic.Contracts;
using BusinessLogic.DataBaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(IIngredientService ingredientService)
        {
            return View();
        }
    }
}