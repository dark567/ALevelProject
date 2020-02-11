using DataLayer;
using DataLayer.Entityes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class JorOrdersController : Controller
    {

        // создаем контекст данных
        EFDBContext db = new EFDBContext();

        // GET: JorOrders
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

            IEnumerable<JorOrder> orders = db.JorOrders.Include(p => p.Client).Include(d =>d.Good);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Num.ToLower().Contains(searchString.ToLower())
                                       || s.DateAdd.Equals(searchString));
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

        // GET: DicGoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JorOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code, Name, Description")]JorOrder jorOrder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.JorOrders.Add(jorOrder);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(jorOrder);
        }

        public ActionResult Create_(Guid? id, bool? saveChangesError = false)
        {
            if (id != null)
            {
                DicClient dicClient = db.DicClients.Find(id);

                if (ModelState.IsValid)
                {
                    ViewBag.Client = dicClient;
                }
                else
                {
                    return PartialView("ListClients_");
                }
            }




            return View();
        }

        // POST: JorOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_(Guid? id)
        {
            try
            {
                DicClient dicClient = db.DicClients.Find(id);

                if (ModelState.IsValid)
                {
                    ViewBag.Client = dicClient;
                }
                else
                {
                    return PartialView("ListClients_");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //return View(client);
            return RedirectToAction("Create_");
        }

        public ActionResult ListClients(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<DicClient> clients = from s in db.DicClients
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.Name.ToLower().Contains(searchString.ToLower())
                                       || s.Surname.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    clients = clients.OrderBy(s => s.BirthDate);
                    break;
                case "date_desc":
                    clients = clients.OrderByDescending(s => s.BirthDate);
                    break;
                default:  // Name ascending 
                    clients = clients.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 5; /*!!!!*/
            int pageNumber = (page ?? 1);
            //return View(clients.ToPagedList(pageNumber, pageSize));

            //// получаем из бд все объекты Book
            //IEnumerable<DicClient> dicClients = db.DicClient;
            //// передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.DicClients = dicClients;
            //// возвращаем представление
            //return View();
            return PartialView("ListClients_", clients.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListClients(DicClient client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DicClients.Add(client);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return PartialView("ListClients_", client);
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListClient(Guid? id)
        {
            try
            {
                DicClient dicClient = db.DicClients.Find(id);

                if (ModelState.IsValid)
                {
                    ViewBag.Client = dicClient;
                }
                else
                {
                    return PartialView("ListClients_");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //return View(client);
            return RedirectToAction("Create_");
        }
        //// POST: JorOrder/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ListClient(string sortOrder, string currentFilter, string searchString, int? page)
        //{

        //    ViewBag.CurrentSort = sortOrder;
        //    ViewBag.DateAddortParm = sortOrder == "dateAdd" ? "num" : "name";
        //    ViewBag.NumSortParm = String.IsNullOrEmpty(sortOrder) ? "num" : "";

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewBag.CurrentFilter = searchString;

        //    IEnumerable<JorOrder> good = from s in db.JorOrder
        //                                 select s;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        good = good.Where(s => s.Num.ToLower().Contains(searchString.ToLower())
        //                               || s.DateAdd.Equals(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "сode":
        //            good = good.OrderByDescending(s => s.DateAdd);
        //            break;
        //        case "name":
        //            good = good.OrderBy(s => s.Num);
        //            break;
        //        case "code_name":
        //            good = good.OrderByDescending(s => s.DateAdd);
        //            break;
        //        default:  // Name ascending 
        //            good = good.OrderBy(s => s.Num);
        //            break;
        //    }

        //    int pageSize = 5; /*!!!!*/
        //    int pageNumber = (page ?? 1);
        //    return View(good.ToPagedList(pageNumber, pageSize));
        //}

        // GET: JorOrder/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorOrder jorOrder = db.JorOrders.Find(id);
            if (jorOrder == null)
            {
                return HttpNotFound();
            }
            return View(jorOrder);
        }

        // GET: JorOrder/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorOrder jorOrder = db.JorOrders.Find(id);
            if (jorOrder == null)
            {
                return HttpNotFound();
            }
            return View(jorOrder);
        }

        // POST: JorOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jorOrderToUpdate = db.JorOrders.Find(id);
            if (TryUpdateModel(jorOrderToUpdate, "",
               new string[] { "Code", "Name", "MinValue", "MaxValue", "Description" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(jorOrderToUpdate);
        }

        // GET: JorOrder/Delete/5
        public ActionResult Delete(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            JorOrder jorOrder = db.JorOrders.Find(id);
            if (jorOrder == null)
            {
                return HttpNotFound();
            }
            return View(jorOrder);
        }

        // POST: JorOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                JorOrder jorOrder = db.JorOrders.Find(id);
                db.JorOrders.Remove(jorOrder);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
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