using DataLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;

namespace LabTestVerThree.Controllers
{
    public class JorAddResultController : Controller
    {
        
        // создаем контекст данных
        EFDBContext db = new EFDBContext();

        // GET: JorAddResult
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateAddortParm = sortOrder == "dateAdd" ? "num" : "name";
            ViewBag.NumSortParm = String.IsNullOrEmpty(sortOrder) ? "num" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //IEnumerable<JorOrder> good = from s in db.JorOrders
            //                             select s;

            IEnumerable<JorAddResult> orders = db.JorAddResults.Include(p => p.Client).Include(d => d.Good);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Num.ToLower().Contains(searchString)
                                       || s.Client.Equals(searchString));
            }
            switch (sortOrder)
            {
                case "сode":
                    orders = orders.OrderByDescending(s => s.DateAdd);
                    break;
                case "name":
                    orders = orders.OrderBy(s => s.Num);
                    break;
                case "code_name":
                    orders = orders.OrderByDescending(s => s.DateAdd);
                    break;
                default:  // Name ascending 
                    orders = orders.OrderBy(s => s.Num);
                    break;
            }

            int pageSize = 5; /*!!!!*/
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}