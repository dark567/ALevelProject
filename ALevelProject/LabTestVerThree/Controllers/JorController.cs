using DataLayer;
using LabTestVerThree.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class JorController : Controller
    {
        // создаем контекст данных
        AppIdentityDbContext db = new AppIdentityDbContext();
        // GET: Test
        public ActionResult Index()
        {
            return View(db.EventDetails.ToList());
        }
    }
}