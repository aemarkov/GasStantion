using GasStantion.EntityFramework;
using GasStantion.Models;

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

            CreateContacts(context);
            CreateHomePageText(context);

            context.SaveChanges();
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
            if(!context.Pages.Any(x=>x.IsMainPage))
            {
                context.Pages.Add(new Page()
                {
                    IsMainPage = true,
                    Title = "Главная",
                    Text = "Текст на главной"
                });
            }
        }
    }
}
