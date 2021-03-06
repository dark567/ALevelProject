﻿using DataLayer;
using DataLayer.Entityes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LabTestVerThree.Models;
using LabTestVerThree.Hubs;
using log4net;

namespace LabTestVerThree.Controllers
{
    [Authorize]
    public class DicClientsController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        // создаем контекст данных
        EFDBContext db = new EFDBContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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

            //IEnumerable<DicClient> clients = from s in db.DicClients
            //                                 select s;

            IEnumerable<DicClient> clients = db.DicClients.Include(p => p.Gender);


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
            return View(clients.ToPagedList(pageNumber, pageSize));
        }

        // GET: DicClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DicClient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Surname, BirthDate")]DicClient client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DicClients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }

        public ActionResult CreateM()
        {
            GenerateGenderList();
            return PartialView("CreateModal");
        }

        private void GenerateGenderList(object selectedGender = null)
        {
            var gendersQuery = from d in db.Genders
                               orderby d.Type
                               select d;
            ViewBag.GenderList = new SelectList(gendersQuery, "GenderId", "Type", selectedGender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateM([Bind(Include = "BirthDate, Name, Surname, Secname, Gender, GenderId, Email, Phone")]DicClient client)
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
                    return PartialView("CreateModal", client);
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }



        // GET: DicClient/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DicClient dicClient = db.DicClients.Find(id);
            if (dicClient == null)
            {
                return HttpNotFound();
            }
            return View(dicClient);
        }

        // GET: DicClient/Details/5
        public ActionResult DetailsModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DicClient dicClient = db.DicClients.Find(id);
            if (dicClient == null)
            {
                return HttpNotFound();
            }
            return PartialView(dicClient);
        }

        // GET: DicClient/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DicClient dicClient = db.DicClients.Find(id);
            if (dicClient == null)
            {
                return HttpNotFound();
            }
            return View(dicClient);
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
            var clientToUpdate = db.DicClients.Find(id);
            if (TryUpdateModel(clientToUpdate, "",
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
            return View(clientToUpdate);
        }

        // GET: DicClient/Edit/5
        public ActionResult EditModal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DicClient dicClient = db.DicClients.Find(id);
            if (dicClient == null)
            {
                return HttpNotFound();
            }
            return PartialView(dicClient);
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
            var clientToUpdate = db.DicClients.Find(id);
            if (TryUpdateModel(clientToUpdate, "",
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
            return PartialView(clientToUpdate);
        }

        // GET: DicClient/Delete/5
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
            DicClient dicClient = db.DicClients.Find(id);
            if (dicClient == null)
            {
                return HttpNotFound();
            }
            return View(dicClient);
        }

        // POST: DicClient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id)
        {
            try
            {
                DicClient dicClient = db.DicClients.Find(id);
                db.DicClients.Remove(dicClient);
                try
                {
                    db.SaveChanges();
                    //SendMessage("Добавлен новый клиент");
                    Log.Info($"Добавлен новый клиент.{dicClient.FullName}");
                }
                catch (DbUpdateException ex)
                {
                    //SendMessage("Ошибка удаления. Клиент уже используется в заказе.");
                    Log.Error($"Error. Client {dicClient.FullName}-{dicClient.ClientId} already using in orders. {ex.Message}");
                    //throw;
                }
               
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
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