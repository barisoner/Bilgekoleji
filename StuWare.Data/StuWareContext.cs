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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //     new User { Username = "Admin", Password = "123", Email = "admin@stuware.com", LastLoginTime = DateTime.Now },
        //     new User { Username = "User1", Password = "123", Email = "user1@stuware.com", LastLoginTime = DateTime.Now },
        //    new User { Username = "User2", Password = "123", Email = "user2@stuware.com", LastLoginTime = DateTime.Now });
        //    //https://www.learnentityframeworkcore.com/migrations/seeding

        //}


    }
}
