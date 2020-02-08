using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTestVerTwo.NavbaR;

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