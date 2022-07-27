using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreRazor.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Escuela> Schools { get; set; }

        public DbSet<Asignatura> Assignments { get; set; }

        public DbSet<Evaluaciones> Evaluations { get; set; }

        public DbSet<Alumno> Students { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }


        // This override method is executed when the db is created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Executes the base function
            base.OnModelCreating(modelBuilder);

            var school = new Escuela()
            {
                Id = Guid.NewGuid().ToString(),
                AñoDeCreación = 2005,
                Nombre = "Platzi",
                Pais = "Colombia",
                Dirección = "Random Direccion.",
                Ciudad = "Bogota",
                TipoEscuela = TiposEscuela.Online
            };

            
            modelBuilder.Entity<Escuela>().HasData(school); // adding the school with the has data method 
            modelBuilder.Entity<Alumno>().HasData(GenerateRandomStudents().ToArray()); // Important send a single item or an array.
            modelBuilder.Entity<Asignatura>().HasData(GenerateRandomAssingments().ToArray());
        }
        private IReadOnlyList<Alumno> GenerateRandomStudents()
        {
            string[] name = { "Freddy", "Alex", "Jorge", "Josh", "Chris" };
            string[] middleName = { "Felix", "John", "Robert", "Samuel", "Rick" };
            string[] lastName = { "Ruiz", "Trump", "Toledo", "Herrera" };

            IEnumerable<Alumno> query = from n in name
                                        from mn in middleName
                                        from l in lastName
                                        select new Alumno { Nombre = n + mn + l, Id = Guid.NewGuid().ToString() };

            return query.ToList<Alumno>();
        } 


        private IReadOnlyList<Asignatura> GenerateRandomAssingments()
        {
            var assignmentsList = new List<Asignatura>() {
                new Asignatura{
                    Nombre = "Matemáticas",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Educación Física",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Castellano",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Ciencias Naturales",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Programacion",
                    Id = Guid.NewGuid ().ToString ()
                }
            };

            return assignmentsList;
        }        

    }
}
