using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.db;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _Created=false;

        public ApplicationDbContext()
        {
            
           
                if (!_Created)
                {
                    _Created = true;
                    Database.EnsureCreated();

                }
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server =(localdb)\MSSQLLocalDB; initial catalog = ASPClass; Integrated Security = True; MultipleActiveResultSets = True; App = EntityFramework & quot; ");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Course> Tbl_Course { set; get; }
        public DbSet<Film> Tbl_Film { set; get; }
        public DbSet<Teater> Tbl_Teater { set; get; }
        public DbSet<Shopping> Tbl_Shopping { set; get; }
        public DbSet<ViewImage> Tbl_Images { set; get; }
        public DbSet<Gallery> Tbl_Gallery { set; get; }
        public DbSet<Invoice> Tbl_Invoice { set; get; }
        public DbSet<OtherServer> Tbl_OtherServer { set; get; }
    }
}
