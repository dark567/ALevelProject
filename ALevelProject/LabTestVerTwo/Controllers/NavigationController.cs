﻿using LabTestVerTwo.NavbaR;
using System.Web.Mvc;

namespace LabTestVerTwo.Controllers
{
    public class NavigationController : Controller
    {
        //// GET: Navigation
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Navbar
        public ActionResult TopNav()
        {
            var nav = new Navbar();
            return PartialView("_topNav", nav.NavbarTop());
        }
    }
}