using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;
using GasStantion.ViewModels;

namespace GasStantion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                

                var feebacks = context.UserFeedbacks
                    .Where(x => x.IsShowOnMain)
                    .OrderByDescending(x => x.Id)
                    .ToList();

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


    }
}