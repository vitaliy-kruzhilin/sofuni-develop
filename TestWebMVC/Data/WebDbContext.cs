using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebMVC.Data.Models;

namespace TestWebMVC.Data
{
    public class WebDbContext : IdentityDbContext<User>
    {
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> WalletHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Wallet>().ToTable("Wallets");
            builder.Entity<WalletHistory>().ToTable("WalletHistory");

            base.OnModelCreating(builder);
        }
    }
}
