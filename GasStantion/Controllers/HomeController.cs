using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;
using GasStantion.ViewModels;

namespace GasStantion.Controllers
{
    public class HomeController : Controller
    {
        //Главная страница
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                //Отзывы, разрешенные к показу на главной
                var feebacks = context.UserFeedbacks
                    .Where(x => x.IsShowOnMain)
                    .OrderByDescending(x => x.Id)
                    .ToList();

                //10 последних новостей
                var news = context.News.OrderByDescending(x => x.Id)
                    .Take(10)
                    .ToList();

                return View(new IndexViewModel()
                {
                    AboutText = "About",
                    News = news,
                    Feedbacks = feebacks
                });
            }

        }

        //Просто дополнительная страница
        public ActionResult Page(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var page = context.Pages.FirstOrDefault(x => x.Id == id);
                if(page==null)
                    throw new HttpException(404, "Не найдено");

                return View(page);
            }
        }

        public ActionResult Contacts()
        {
            return View();
        }


    }
}