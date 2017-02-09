using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasStantion.EntityFramework;
using GasStantion.ViewModels;

namespace GasStantion.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var documents = context.Documents
                    .Select(x => new DocumentListItemViewModel()
                    {
                        Id = x.Id,
                        DocumentName = x.DocumentName
                    })
                    .ToList();

                return View(documents);
            }
        }

        //Просмотр выбранного документа - всех изображений
        public ActionResult Document(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var document = context.Documents.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
                if(document==null)
                    throw new HttpException(404,"Не найдено");

                 return View(document);
            }

        }
    }
}