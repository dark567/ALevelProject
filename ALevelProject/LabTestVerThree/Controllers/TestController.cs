﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class TestController : Controller
    {
        // создаем контекст данных
        EFDBContext db = new EFDBContext();
        // GET: Test
        public ActionResult Index()
        {
            return View(db.DicClients.ToList());
        }
    }
}