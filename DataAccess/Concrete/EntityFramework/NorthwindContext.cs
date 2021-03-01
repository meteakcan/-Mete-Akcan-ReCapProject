using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context : db tabloları ile proje classlarını bağlamak.
    //SOLID
    //O:Open Closed Principle
    public class NorthwindContext : DbContext //DbContext : EntityFramework ile geliyor.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarDatabase;Trusted_Connection=true"); //uydurma ip @:/yi normal olarak algıla 
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands{ get; set; }
    }
}
