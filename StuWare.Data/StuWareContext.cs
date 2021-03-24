using Microsoft.EntityFrameworkCore;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StuWare.Data
{
    public class StuWareContext : DbContext
    {
        public StuWareContext(DbContextOptions<StuWareContext> options) : base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Lesson> Lesson { get; set; }

        public DbSet<StudentLesson> StudentLesson { get; set; }
        public DbSet<StudentLessonGrade> StudentLessonGrade { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Panel> Panel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
             new City { ID = 34, Name = "İstanbul" },
            new City { ID = 41, Name = "Kocaeli" }
             );


            modelBuilder.Entity<District>().HasData(
             new District { ID = 1, Name = "İzmit", CityID = 41 },
             new District { ID = 2, Name = "Değirmendere", CityID = 41 },
             new District { ID = 3, Name = "Karamürsel", CityID = 41 },
             new District { ID = 4, Name = "Gölcük", CityID = 41 },
              new District { ID = 5, Name = "Kadıköy", CityID = 34 },
              new District { ID = 6, Name = "Bostancı", CityID = 34 },
              new District { ID = 7, Name = "Taksim", CityID = 34 },
              new District { ID = 8, Name = "Maltepe", CityID = 34 }
            
             );
            

        }


    }
}
