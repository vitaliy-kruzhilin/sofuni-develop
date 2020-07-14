using RentVacation.Dealers.Data.Models;
using RentVacation.Common.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace RentVacation.Dealers.Data
{
    public class DataSeeder : IDataSeeder
    {
        private static IEnumerable<Category> GetData()
               => new List<Category>
               {
                new Category{ Name = "Garage", Description = "Middle garage" },
                new Category{ Name = "Studio", Description = "Small studio." },
                new Category{ Name = "Apartament", Description = "Normal apartament." },
                new Category{ Name = "House", Description = "Big house." },
                new Category{ Name = "Van", Description = "Stupid Van." }
               };

        private readonly DealersDbContext db;

        public DataSeeder(DealersDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Categories.Any())
            {
                return;
            }

            foreach (var category in GetData())
            {
                this.db.Categories.Add(category);
            }

            this.db.SaveChanges();
        }
    }
}
