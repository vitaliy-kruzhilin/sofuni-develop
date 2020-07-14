using Microsoft.AspNetCore.Identity;
using RentVacation.Common;
using RentVacation.Identity.Data.Models;
using RentVacation.Common.Services.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Identity.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    var adminRole = new IdentityRole(Constants.AdministratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new User
                    {
                        UserName = "admin@boroboro.ops",
                        Email = "admin@boroboro.ops",
                        SecurityStamp = "SuperSecurityStamp"
                    };

                    await userManager.CreateAsync(adminUser, "qwerty123");

                    await userManager.AddToRoleAsync(adminUser, Constants.AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();

        }
    }
}
