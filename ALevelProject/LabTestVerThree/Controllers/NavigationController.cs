using LabTestVerThree.NavbaR;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navbar
        public ActionResult TopNav()
        {
            var nav = new Navbar();
            return PartialView("_topNav", nav.NavbarTop());
        }
    }
}