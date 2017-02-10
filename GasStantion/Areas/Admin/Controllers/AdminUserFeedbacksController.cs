using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;
using GasStantion.Models;

namespace GasStantion.Areas.Admin.Controllers
{
    public class AdminUserFeedbacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminUserFeedbacks
        public ActionResult Index()
        {
            return View(db.UserFeedbacks.ToList());
        }

        // GET: Admin/AdminUserFeedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminUserFeedbacks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Stars,Comment,IsShowOnMain")] UserFeedback userFeedback)
        {
            if (ModelState.IsValid)
            {
                db.UserFeedbacks.Add(userFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userFeedback);
        }

        // GET: Admin/AdminUserFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFeedback userFeedback = db.UserFeedbacks.Find(id);
            if (userFeedback == null)
            {
                return HttpNotFound();
            }
            return View(userFeedback);
        }

        // POST: Admin/AdminUserFeedbacks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Stars,Comment,IsShowOnMain")] UserFeedback userFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userFeedback);
        }
                
        public ActionResult Delete(int id)
        {
            UserFeedback userFeedback = db.UserFeedbacks.Find(id);
            db.UserFeedbacks.Remove(userFeedback);
            db.SaveChanges();
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
