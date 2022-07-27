using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreRazor.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }


        // This override method is executed when the db is created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Executes the base function
            base.OnModelCreating(modelBuilder);

            var school = new School()
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = 2005,
                Name = "Platzi",
                Country = "Colombia",
                Address = "Random Direccion.",
                City = "Bogota",
                SchoolType = SchoolType.Online
            };


            modelBuilder.Entity<School>().HasData(school); // adding the school with the has data method 
            modelBuilder.Entity<Student>().HasData(GenerateRandomStudents().ToArray()); // Important send a single item or an array.
            modelBuilder.Entity<Assignment>().HasData(GenerateRandomAssingments().ToArray());
        }
        private IReadOnlyList<Student> GenerateRandomStudents()
        {
            string[] name = { "Freddy", "Alex", "Jorge", "Josh", "Chris" };
            string[] middleName = { "Felix", "John", "Robert", "Samuel", "Rick" };
            string[] lastName = { "Ruiz", "Trump", "Toledo", "Herrera" };

            IEnumerable<Student> query = from n in name
                                         from mn in middleName
                                         from l in lastName
                                         select new Student { Name = n + mn + l, Id = Guid.NewGuid().ToString() };

            return query.ToList<Student>();
        }


        private IReadOnlyList<Assignment> GenerateRandomAssingments()
        {
            var assignmentsList = new List<Assignment>() {
                new Assignment{
                    Name = "Matemáticas",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Assignment {
                    Name = "Educación Física",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Assignment {
                    Name = "Castellano",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Assignment {
                    Name = "Ciencias Naturales",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Assignment {
                    Name = "Programacion",
                    Id = Guid.NewGuid ().ToString ()
                }
            };

            return assignmentsList;
        }

    }
}
