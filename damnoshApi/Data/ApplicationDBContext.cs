using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Mappers;
using damnoshApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace damnoshApi.Data
{
    public class ApplicationDBContext : IdentityDbContext<AddUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppuserId, p.StockId }));
            builder.Entity<Portfolio>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Portfolio)
            .HasForeignKey(p => p.AppuserId);

            builder.Entity<Portfolio>()
            .HasOne(u => u.Stock)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="ADMIN",

                },

                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER",
                },

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}