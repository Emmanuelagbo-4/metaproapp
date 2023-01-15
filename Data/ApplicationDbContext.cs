using System;
using metaproapp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace metaproapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) 
        {
            

        }
        
        DbSet<ApplicationUser> ApplicationUsers {get; set;}
        DbSet<Team> Teams {get; set;}
        DbSet<Payment> Payments {get; set;}
        
    }
}
