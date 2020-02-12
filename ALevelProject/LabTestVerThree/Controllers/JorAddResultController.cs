using DataLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using System.Net;
using System.Data.Entity.Infrastructure;

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

        // GET: JorResult/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorAddResult jorAddResult = db.JorAddResults.Find(id);

            DicClient client = db.DicClients.Find(jorAddResult.ClientId);
            DicGood good = db.DicGoods.Find(jorAddResult.GoodId);

            db.JorAddResults.Where(p => p.ClientId == client.ClientId).Load();
            db.JorAddResults.Where(p => p.GoodId == good.GoodId).Load();

            if (jorAddResult == null)
            {
                return HttpNotFound();
            }
            return View(jorAddResult);
        }

        // GET: JorResult/Details/5
        public ActionResult DetailsModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorAddResult jorAddResult = db.JorAddResults.Find(id);

            if (jorAddResult == null)
            {
                return HttpNotFound();
            }
            return PartialView(jorAddResult);
        }

        // GET: DicClient/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorAddResult jorAddResult = db.JorAddResults.Find(id);

            DicClient client = db.DicClients.Find(jorAddResult.ClientId);
            DicGood good = db.DicGoods.Find(jorAddResult.GoodId);

            db.JorAddResults.Where(p => p.ClientId == client.ClientId).Load();
            db.JorAddResults.Where(p => p.GoodId == good.GoodId).Load();

            if (jorAddResult == null)
            {
                return HttpNotFound();
            }
            return View(jorAddResult);
        }


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
            JorAddResult jorAddResult = db.JorAddResults.Find(id);

            if (TryUpdateModel(jorAddResult, "",
               new string[] { "Value", "Description", "IsFinished" }))
            {
                try
                {
                    db.SaveChanges();

                    AddJorAddResults(jorAddResult);
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(jorAddResult);
        }

        private static void AddJorAddResults(JorAddResult jorAddResult)
        {
            if (jorAddResult.IsFinished == true)
            {
                JorResult jorResult = new JorResult()
                {
                    DateAdd = jorAddResult.DateAdd,
                    DateDone = jorAddResult.DateAdd,
                    Num = jorAddResult.Num,

                    ClientId = jorAddResult.ClientId,
                    GoodId = jorAddResult.GoodId,
                    Value = jorAddResult.Value,
                    Description = jorAddResult.Description
                };

                using (EFDBContext db = new EFDBContext())
                {
                    db.JorResults.Add(jorResult);
                    db.SaveChanges();
                }

            }
        }

        // GET: DicClient/Edit/5
        public ActionResult EditModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorAddResult jorAddResult = db.JorAddResults.Find(id);

            if (jorAddResult == null)
            {
                return HttpNotFound();
            }
            return PartialView(jorAddResult);
        }

        // POST: DicClient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("EditModal")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPostModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorAddResult jorAddResult = db.JorAddResults.Find(id);

            if (TryUpdateModel(jorAddResult, "",
               new string[] { "DateDone", "Value", "Description", "IsFinished" }))
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
            return PartialView(jorAddResult);
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