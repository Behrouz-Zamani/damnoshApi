using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace damnoshApi.Data
{
    public class ApplicationDBContext : IdentityDbContext<AddUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks{get;set;}
        public DbSet<Comment> Comments{get;set;}
    }
}