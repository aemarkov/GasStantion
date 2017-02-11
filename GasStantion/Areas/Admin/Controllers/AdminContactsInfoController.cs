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
    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Moderator)]
    public class AdminContactsInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Edit()
        {
            var contactsInfo = db.Contacts.FirstOrDefault();                        
            if (contactsInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactsInfo);
        }
        
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
