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
    public class AdminContactsInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
                
        // GET: Admin/AdminContactsInfo/Edit/5
        public ActionResult Edit()
        {
            var contactsInfo = db.Contacts.FirstOrDefault();                        
            if (contactsInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactsInfo);
        }

        // POST: Admin/AdminContactsInfo/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,Phone,Address,YandexMapUrl")] ContactsInfo contactsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(contactsInfo);
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
