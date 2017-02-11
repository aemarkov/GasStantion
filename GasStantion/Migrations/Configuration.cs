using System.Data.Entity.Validation;
using System.Web;
using GasStantion.EntityFramework;
using GasStantion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GasStantion.EntityFramework.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /*private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }*/


        protected override void Seed(GasStantion.EntityFramework.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /*if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }*/

            CreateContacts(context);
            CreateHomePageText(context);

            CreateTag(context, "Новости компании");
            CreateTag(context, "Новости промышленности");
            CreateTag(context, "Экология");
            CreateTag(context, "Топливо");
            CreateTag(context, "Разное");

            context.SaveChanges();

            CreateRoleIfNotExists(context, RoleNames.Admin);
            CreateRoleIfNotExists(context, RoleNames.Moderator);
            context.SaveChanges();

            CreateUserIfotExists(context, "admin", "adminpass", RoleNames.Admin);
        }

        //Создает запись контактов
        private void CreateContacts(ApplicationDbContext context)
        {
            if (!context.Contacts.Any())
            {
                context.Contacts.Add(new ContactsInfo());
            }
        }

        //Создает текст для главной страницы
        private void CreateHomePageText(ApplicationDbContext context)
        {
            if (!context.Pages.Any(x => x.IsMainPage))
            {
                context.Pages.Add(new Page()
                {
                    IsMainPage = true,
                    Title = "Главная",
                    Text = "Текст на главной"
                });
            }
        }

        //Создает роль
        private void CreateRoleIfNotExists(ApplicationDbContext context, string name)
        {
            if (!context.Roles.Any(x => x.Name == name))
            {
                context.Roles.Add(new IdentityRole() { Name = name });
            }
        }

        //Создает пользователя
        private void CreateUserIfotExists(ApplicationDbContext context, string username, string password, params string[] roles)
        {
            if (!context.Users.Any(u => u.UserName == username))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = username, PhoneNumber = "" };

                //Добавляем роли
                if (roles != null)
                {
                    foreach (var roleName in roles)
                    {
                        var role = context.Roles.FirstOrDefault(x => x.Name == roleName);
                        if (role != null)
                        {
                            user.Roles.Add(new IdentityUserRole() { RoleId = role.Id, UserId = user.Id });
                        }
                    }
                }

                userManager.Create(user, password);


            }
        }

        //Создает тег
        private void CreateTag(ApplicationDbContext context, string tag)
        {
            if (!context.Tags.Any(x => x.TagName == tag))
                context.Tags.Add(new Tag() {TagName = tag});
        }
    }
}
