using LabTestVerThree.Filters;
using log4net;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));


        [LogConnection]
        public ActionResult Index()
        {
            Log.Info("Start HomeController");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}