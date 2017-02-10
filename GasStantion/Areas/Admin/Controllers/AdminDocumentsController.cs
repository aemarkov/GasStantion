using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GasStantion.Areas.Admin.ViewModels;
using GasStantion.EntityFramework;
using GasStantion.Models;

namespace GasStantion.Areas.Admin.Controllers
{
    public class AdminDocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminDocuments
        public ActionResult Index()
        {
            return View(db.Documents.ToList());
        }

        // GET: Admin/AdminDocuments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDocuments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DocumentName")] Document document)
        {
            if (ModelState.IsValid)
            {
                UploadFiles(document, HttpContext.Request.Files);

                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(document);
        }

        //Загружает файлы изображений для этого документа
        private void UploadFiles(Document document, HttpFileCollectionBase files)
        {
            if (files == null || files.Count == 0)
                return;

            foreach (HttpPostedFileBase file in files)
            {
                var documentImage = new DocumentImage() {ImageUrl = FileUploader.UploadFile(file)};
                document.Images.Add(documentImage);
            }
        }

        // GET: Admin/AdminDocuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Admin/AdminDocuments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DocumentName")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(document);
        }

        // GET: Admin/AdminDocuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Admin/AdminDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
