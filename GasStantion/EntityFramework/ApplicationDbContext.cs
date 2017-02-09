using System.Data.Entity;
using GasStantion.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GasStantion.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<News> News { get; set; } 
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<Page> Pages { get; set; }
        public IDbSet<Document> Documents { get; set; } 
        public IDbSet<DocumentImage> DocumentImages { get; set; }
        public IDbSet<FuelPrice> FuelPrices { get; set; } 
        public IDbSet<UserFeedback> UserFeedbacks { get; set; } 
    }
}