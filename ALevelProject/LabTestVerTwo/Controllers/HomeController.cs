﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTestVerTwo.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //public ActionResult Test()
        //{
        //    Dictionary<string, object> data
        //        = new Dictionary<string, object>();
        //    data.Add("Ключ", "Значение");

        //    return View(data);
        //}

        //[Authorize]
        //public ActionResult Index()
        //{
        //    return View(GetData("Index"));
        //}



        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}