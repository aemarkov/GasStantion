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
    /// Просмотр подробной информации о топливе
    /// </summary>
    public class FuelController : Controller
    {
        // GET: Fuel
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var fuels = context.Fuels
                    .Select(x => new FuelListItemViewModel()
                    {
                        Id = x.Id,
                        FuelName = x.FuelName
                    })
                    .ToList();

                return View(fuels);
            }
        }

        public ActionResult Type(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var fuel = context.Fuels.FirstOrDefault(x => x.Id == id);

                if(fuel==null)
                    throw new HttpException(404, "Не найдено");

                return View(fuel);
            }
        }
    }
}