using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private static int[] ids = {1, 2, 3, 4, 5};


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetArticle(int id)
        {
            //HandleErrorAttribute
            if (ids.All(x => x != id))
                return HttpNotFound();
            return View();
        }

        public ActionResult GetNews(int id)
        {

            if (ids.All(x => x != id))
                throw new HttpException(404, "Not found!");
            return View("GetArticle");
        }
    }
}