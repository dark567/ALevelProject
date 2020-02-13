using LabTestVerThree.NavbaR;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class NavigationController : Controller
    {

        // GET: Navbar
        public ActionResult TopNav()
        {
            

            if (User.IsInRole("admins"))
            {
                var nav = new NavbarAdmin();
                return PartialView("_topNav", nav.NavbarTop());
            }
            if (User.IsInRole("managers"))
            {
                var nav = new NavbarManager();
                return PartialView("_topNav", nav.NavbarTop()); }
            if (User.IsInRole("laborants"))
            {
                var nav = new NavbarLaborant();
                return PartialView("_topNav", nav.NavbarTop());
            }
            else
            {
                var nav = new NavbarManager();
                return PartialView("_topNav", nav.NavbarTop());
            }
        }
    }
}