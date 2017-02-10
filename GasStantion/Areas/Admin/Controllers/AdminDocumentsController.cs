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
            return View(new EditDocumentViewModel());
        }

        // POST: Admin/AdminDocuments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditDocumentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var document = new Document() {DocumentName = model.DocumentName};

            db.Documents.Add(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Admin/AdminDocuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Documents
                .Where(x => x.Id == id)
                .Select(x => new EditDocumentViewModel()
                {
                    Id = x.Id,
                    DocumentName = x.DocumentName,
                    Images = x.Images
                })
                .FirstOrDefault();
                

            return View(model);
        }

        // POST: Admin/AdminDocuments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditDocumentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var document = db.Documents.Include(x => x.Images).FirstOrDefault(x => x.Id == model.Id);
            if(document==null)
                throw new HttpException(404, "Не найдено");

            document.DocumentName = model.DocumentName;

            //Загружаем изображение, если есть
            if (model.UploadedImage != null && model.UploadedImage.ContentLength > 0)
            {
                var image = new DocumentImage() {ImageUrl = FileUploader.UploadFile(model.UploadedImage)};
                document.Images.Add(image);
            }

            //Сохраняем изменения
            db.Entry(document).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit", "AdminDocuments",new {id=model.Id});
        }

        //Удалить загруженное изображение
        public ActionResult RemoveImage(int id)
        {
            var image = db.DocumentImages.FirstOrDefault(x => x.Id == id);
            if(image==null)
                throw new HttpException(404,"Не найдено");

            if (FileUploader.RemoveFile(image.ImageUrl))
            {
                db.DocumentImages.Remove(image);
                db.SaveChanges();
            }

            return RedirectToAction("Edit", "AdminDocuments", new { id = image.DocumentId });
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
