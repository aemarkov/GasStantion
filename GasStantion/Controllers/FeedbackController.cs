using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;
using GasStantion.Models;

namespace GasStantion.Controllers
{
    //Просмотр отзывыво
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var model = context.UserFeedbacks.OrderByDescending(x => x.Id).ToList();
                return View(model);
            }
        }

        //Создание нового отзывы
        [HttpGet]
        public ActionResult New()
        {
            return View(new UserFeedback());
        }

        public ActionResult New(UserFeedback model)
        {
            if(!ModelState.IsValid)
                return View(model);

            using (var context = new ApplicationDbContext())
            {
                context.UserFeedbacks.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}