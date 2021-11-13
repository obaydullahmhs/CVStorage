using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    object p = modelBuilder.Entity<Person>().HasData(
        //        new Person
        //        {
                    

        //        }
        //        );
        //    ;
        //}

    }
}
