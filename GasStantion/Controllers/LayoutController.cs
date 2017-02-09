using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;
using GasStantion.ViewModels;

namespace GasStantion.Controllers
{
    /// <summary>
    /// Контроллер для кусков лейоута
    /// </summary>
    public class LayoutController : Controller
    {
        //Доп. пункты меню
        public PartialViewResult Menu()
        {
            using (var context = new ApplicationDbContext())
            {
                var model = context.Pages
                    .Select(x => new MenuItemViewModel()
                    {
                        Id = x.Id,
                        Title = x.Title
                    })
                    .ToList();

                return PartialView("Partials/_MenuPartial",model);
            }
        }

        //Шапка
        public PartialViewResult Header()
        {
            return PartialView("Partials/_HeaderPartial",new HeaderViewModel() {Title = "АГЗС «Пионер»", Phone = "8-969-290-54-93" });
        }

        //Цены на газ
        public PartialViewResult Fuel()
        {
            using (var context = new ApplicationDbContext())
            {
                var model = context.Fuels
                    .Select(x => new FuelPriceListItemViewModel()
                    {
                        Id = x.Id,
                        FuelName = x.FuelName,
                        Price = x.Price
                    })
                    .ToList();

                return PartialView("Partials/_FuelPartial", model);
            }

                
        }
    }

}