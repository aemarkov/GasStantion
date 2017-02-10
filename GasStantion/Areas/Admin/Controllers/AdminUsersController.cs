using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GasStantion.Areas.Admin.ViewModels;
using GasStantion.EntityFramework;
using GasStantion.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace GasStantion.Areas.Admin.Controllers
{
    /// <summary>
    /// Управение пользователями
    /// </summary>
    [Authorize(Roles = RoleNames.Admin)]
    public class AdminUsersController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        private ApplicationDbContext db;

        public AdminUsersController()
        {
            db = new ApplicationDbContext();
        }

        // GET: AdminUser
        public ActionResult Index()
        {
            //Получаем список пользователей
            //Каждый пользователь имеет единственную роль,
            //поэтому можем так делать

            var users = db.Users
                .Select(x => new UserListItemViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                    Username = x.UserName,
                    Role = db.Roles.FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId).Name
                })
                .ToList();

            return View(users);
        }

        //Создание нового пользователя
        [HttpGet]
        public ActionResult Create()
        {
            return View(new RegisterViewModel { Roles = GetRoles() });
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ValidationException();

                if (model.RoleId == null)
                {
                    ModelState.AddModelError(nameof(model.RoleId),"Выберите роль");
                    throw new ValidationException();
                }


                //Регистрируем пользователя
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                

                //Назначаем роль
                var role = db.Roles.FirstOrDefault(x => x.Id == model.RoleId);
                if (role == null)
                {
                    ModelState.AddModelError(nameof(model.RoleId), "Роль не найдена");
                    throw new ValidationException();
                }

                user.Roles.Add(new IdentityUserRole() {RoleId = model.RoleId, UserId = user.Id});



                var result = await UserManager.CreateAsync(user, model.Password);

                //Проверка ошибок регистрации
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }

                    throw  new ValidationException();
                }
            }
            catch (ValidationException ex)
            {
                model.Roles = GetRoles();
                return View(model);
            }

            return RedirectToAction("Index", "AdminUsers");
        }

       
        //Загружает список ролей
        private IEnumerable<SelectListItem> GetRoles()
        {
            return db.Roles
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id
                });
        }


        //Удалить пользователя
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Users
                .Where(x => x.Id == id)
                .Select(x => new DeleteUserViewModel()
                {
                    Id=x.Id,
                    UserName = x.UserName
                })
                .FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/AdminDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}