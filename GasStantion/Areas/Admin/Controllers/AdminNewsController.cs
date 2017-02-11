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
using GasStantion.Areas.Admin.ViewModels;

namespace GasStantion.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Moderator)]
    public class AdminNewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Index()
        {
            return View(db.News.OrderByDescending(x=>x.Id).ToList());
        }
         
        public ActionResult Create()
        {
            LoadTags();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,PreviewImageUrl,ShortDescription")] News news, HttpPostedFileBase PreviewFile, IEnumerable<int> tagIds )
        {
            var fileUrl = string.Empty;
            if (PreviewFile != null && PreviewFile.ContentLength > 0)
            {
                fileUrl = FileUploader.UploadFile(PreviewFile);
            }

            if (ModelState.IsValid)
            {
                news.PreviewImageUrl = fileUrl;
                news.Tags = db.Tags.Where(x => tagIds.Any(t => t == x.Id)).ToList();
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            LoadTags();
            return View(news);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Include(x=>x.Tags).FirstOrDefault(x=>x.Id==id);
            ViewBag.tagIds = news.Tags.Select(x => x.Id).ToList();
            if (news == null)
            {
                return HttpNotFound();
            }

            LoadTags();
            return View(news);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,PreviewImageUrl,ShortDescription")] News news, HttpPostedFileBase PreviewFile, IEnumerable<int> tagIds )
        {            
            if (PreviewFile != null && PreviewFile.ContentLength > 0)
            {
                news.PreviewImageUrl = FileUploader.UploadFile(PreviewFile);
            }
            
            if (ModelState.IsValid)
            {
                var loadedNews = db.News.Include(x=>x.Tags).FirstOrDefault(x => x.Id == news.Id);
                if(loadedNews==null)
                    throw new HttpException(404,"Не найдено");

                loadedNews.Tags = db.Tags.Where(x => tagIds.Any(t => t == x.Id)).ToList();
                loadedNews.PreviewImageUrl = news.PreviewImageUrl;
                loadedNews.Title = news.Title;
                loadedNews.ShortDescription = news.ShortDescription;
                loadedNews.Text = news.Text;

                db.Entry(loadedNews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            LoadTags();
//            ViewBag.tagIds = news.Tags.Select(x => x.Id).ToList();
            return View(news);
        }

        //Загружает список тегов
        private void LoadTags()
        {
            ViewBag.Tags = db.Tags
                .Select(x => new SelectListItem()
                {
                    Text = x.TagName,
                    Value = x.Id.ToString()
                })
                .ToList();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
