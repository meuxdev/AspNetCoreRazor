using Microsoft.EntityFrameworkCore;

namespace CoursePractice.Models
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


    }
}
