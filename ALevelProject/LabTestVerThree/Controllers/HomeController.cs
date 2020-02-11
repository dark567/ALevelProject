using LabTestVerThree.Filters;
using log4net;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        [Authorize]
        [LogConnection]
        public ActionResult Index()
        {
            Log.Info("Start HomeController");

            return View();
        }
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