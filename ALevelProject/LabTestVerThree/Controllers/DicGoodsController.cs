using DataLayer;
using DataLayer.Entityes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class DicGoodsController : Controller
    {
        // создаем контекст данных
        EFDBContext db = new EFDBContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CodeSortParm = sortOrder == "сode" ? "date_desc" : "name";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "сode" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<DicGood> good = from s in db.DicGoods
                                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                good = good.Where(s => s.Code.ToLower().Contains(searchString.ToLower())
                                       || s.Name.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "сode":
                    good = good.OrderByDescending(s => s.Code);
                    break;
                case "name":
                    good = good.OrderBy(s => s.Name);
                    break;
                case "code_name":
                    good = good.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    good = good.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 5; /*!!!!*/
            int pageNumber = (page ?? 1);
            return View(good.ToPagedList(pageNumber, pageSize));
        }

        // GET: DicGoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DicGoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code, Name, Description")]DicGood good)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DicGoods.Add(good);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(good);
        }

        // GET: DicGoods/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DicGood dicGood = db.DicGoods.Find(id);
            if (dicGood == null)
            {
                return HttpNotFound();
            }
            return View(dicGood);
        }

        // GET: DicGoods/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DicGood dicGood = db.DicGoods.Find(id);
            if (dicGood == null)
            {
                return HttpNotFound();
            }
            return View(dicGood);
        }

        // POST: DicGoods/Edit/5
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
            var goodToUpdate = db.DicGoods.Find(id);
            if (TryUpdateModel(goodToUpdate, "",
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
            return View(goodToUpdate);
        }

        // GET: DicGoods/Delete/5
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
            DicGood dicGood = db.DicGoods.Find(id);
            if (dicGood == null)
            {
                return HttpNotFound();
            }
            return View(dicGood);
        }

        // POST: DicGoods/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                DicGood dicGood = db.DicGoods.Find(id);
                db.DicGoods.Remove(dicGood);
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