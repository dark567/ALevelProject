using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DataLayer.Entityes;
using PagedList;
using System.Net;
using System.Data.Entity.Infrastructure;
using LabTestVerThree.Models;

namespace LabTestVerThree.Controllers
{
    [Authorize]
    public class JorResultController : Controller
    {
        // создаем контекст данных
        EFDBContext db = new EFDBContext();

        // GET: JorResult
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateOrdSortParm = sortOrder == "dateAdd" ? "num" : "name";
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

            IEnumerable<JorResult> results = db.JorResults.Include(p => p.Client).Include(d => d.Good);

            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.Num.Contains(searchString)
                                       || s.Client.Equals(searchString));
            }
            switch (sortOrder)
            {
                case "сode":
                    results = results.OrderByDescending(s => s.DateAdd);
                    break;
                case "name":
                    results = results.OrderBy(s => s.Num);
                    break;
                case "code_name":
                    results = results.OrderByDescending(s => s.DateAdd);
                    break;
                default:  // Name ascending 
                    results = results.OrderBy(s => s.Num);
                    break;
            }

            int pageSize = 5; /*!!!!*/
            int pageNumber = (page ?? 1);
            return View(results.ToPagedList(pageNumber, pageSize));
        }

        // GET: JorResult/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorResult jorResult = db.JorResults.Find(id);

            DicClient client = db.DicClients.Find(jorResult.ClientId);
            DicGood good = db.DicGoods.Find(jorResult.GoodId);

            db.JorResults.Where(p => p.ClientId == client.ClientId).Load();
            db.JorResults.Where(p => p.GoodId == good.GoodId).Load();

            if (jorResult == null)
            {
                return HttpNotFound();
            }
            return View(jorResult);
        }

        // GET: JorResult/Details/5
        public ActionResult DetailsModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorResult jorResult = db.JorResults.Find(id);
            if (jorResult == null)
            {
                return HttpNotFound();
            }
            return PartialView(jorResult);
        }

        // GET: DicClient/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JorResult jorResult = db.JorResults.Find(id);

            Session["Result"] = jorResult;

            DicClient client = db.DicClients.Find(jorResult.ClientId);
            DicGood good = db.DicGoods.Find(jorResult.GoodId);

            db.JorResults.Where(p => p.ClientId == client.ClientId).Load();
            db.JorResults.Where(p => p.GoodId == good.GoodId).Load();

            if (jorResult == null)
            {
                return HttpNotFound();
            }
            return View(jorResult);
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
            JorResult jorResult = db.JorResults.Find(id);
            if (TryUpdateModel(jorResult, "",
               new string[] { "Email", "IsSent" }))
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
            return View(jorResult);
        }

        // GET: DicClient/Edit/5
        public ActionResult EditModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JorResult jorResult = db.JorResults.Find(id);

            if (jorResult == null)
            {
                return HttpNotFound();
            }
            return PartialView(jorResult);
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
            JorResult jorResult = db.JorResults.Find(id);

            if (TryUpdateModel(jorResult, "",
               new string[] { "Name", "Surname", "BirthDate" }))
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
            return PartialView(jorResult);
        }

        public ActionResult SendEmail(Guid? id)
        {
            //if (id == null )
            //{
            //    JorResult jorResult = (JorResult)(Session["Result"]);
            //}
            JorResult jorResult = (JorResult)(Session["Result"]);

            EmailModel emailModel = new EmailModel()
            {
                Subject = "Teat",
                From = "admin@gmail.com",
                To = jorResult.Client.Email,
                Body = $"Ваши результаты:{jorResult.Value} {jorResult.Description}"
            };

            return PartialView(emailModel);
        }

        [HttpPost]
        public ActionResult SendEmail(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new EmailController().SendEmail(model).Deliver();

                    return RedirectToAction("Success");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }
            }
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
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