using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;

namespace GasStantion.Controllers
{
    public class NewsController : Controller
    {
        //Все новости
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var news = context.News.ToList();
                return View(news);
            }
        }

        //Выбранная новость
        public ActionResult News(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var news = context.News.Include(x=>x.Tags).FirstOrDefault(x => x.Id == id);
                if(news==null)
                    throw new HttpException(404, "Не найдено");

                return View(news);
            }
        }

        //Показывает новости по заданному тегу
        public ActionResult ByTag(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                ViewBag.Tag = context.Tags.FirstOrDefault(x => x.Id == id)?.TagName;
                var news = context.News.Where(x => x.Tags.Any(t => t.Id == id)).ToList();
                return View(news);
            }
        }
    }
}