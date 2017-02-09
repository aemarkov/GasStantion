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
                    .Where(x=>!x.IsMainPage)
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
            using (var context = new ApplicationDbContext())
            {
                var model = context.Contacts
                    .Select(x => new HeaderViewModel()
                    {
                        Title = x.CompanyName,
                        Phone = x.Phone
                    })
                    .FirstOrDefault();

                return PartialView("Partials/_HeaderPartial", model);
            }

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