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

            var courses = GenerateRandomCourses(school);
            var students = GenerateRandomStudents(30, courses);
            var assignments = GenerateRandomAssignments(courses);
            var grades = GenerateRandomGrades(students, assignments);


            modelBuilder.Entity<School>().HasData(school); // adding the school with the has data method 
            modelBuilder.Entity<Student>().HasData(students.ToArray()); // Important send a single item or an array.
            modelBuilder.Entity<Assignment>().HasData(assignments.ToArray());
            modelBuilder.Entity<Course>().HasData(courses.ToArray());
            modelBuilder.Entity<Grade>().HasData(grades.ToArray());

        }

        private IEnumerable<Student> GenerateRandomStudents(int amount, IEnumerable<Course> courses)
        {

            string[] name = { "Freddy", "Alex", "Jorge", "Josh", "Chris" };
            string[] middleName = { "Felix", "John", "Robert", "Samuel", "Rick" };
            string[] lastName = { "Ruiz", "Trump", "Toledo", "Herrera" };

            List<Student> totalStudents = new List<Student>();

            foreach (var course in courses)
            {
                IEnumerable<Student> students = from n in name
                                                from mn in middleName
                                                from l in lastName
                                                select new Student { Name = n + mn + l, Id = Guid.NewGuid().ToString(), CourseId = course.Id };

                totalStudents.AddRange(students.Take(amount));

            }

            return totalStudents;
        }

        private IEnumerable<Course> GenerateRandomCourses(School school)
        {
            var schoolId = school.Id;
            var courseList = new List<Course>() {
                new Course { Id = Guid.NewGuid().ToString(), Name = "101", SchoolId = schoolId, ScheduleType = ScheduleType.Noche },
                new Course { Id = Guid.NewGuid().ToString(), Name = "103", SchoolId = schoolId, ScheduleType = ScheduleType.Mañana },
                new Course { Id = Guid.NewGuid().ToString(), Name = "105", SchoolId = schoolId, ScheduleType = ScheduleType.Tarde },
                new Course { Id = Guid.NewGuid().ToString(), Name = "107", SchoolId = schoolId, ScheduleType = ScheduleType.Mañana },
            };

            return courseList;
        }

        private IEnumerable<Assignment> GenerateRandomAssignments(IEnumerable<Course> courses)
        {
            var assignmentList = new List<Assignment>();
            foreach (var course in courses)
            {
                var temp = new List<Assignment>();
                // Generate random Assgnments
                temp.Add(new Assignment { Name = "Math", Id = Guid.NewGuid().ToString(), CourseId = course.Id });
                temp.Add(new Assignment { Name = "Physics", Id = Guid.NewGuid().ToString(), CourseId = course.Id });
                temp.Add(new Assignment { Name = "Computer Science", Id = Guid.NewGuid().ToString(), CourseId = course.Id });
                temp.Add(new Assignment { Name = "English", Id = Guid.NewGuid().ToString(), CourseId = course.Id });
                assignmentList.AddRange(temp);
            }

            return assignmentList;
        }

        private IEnumerable<Grade> GenerateRandomGrades(IEnumerable<Student> students, IEnumerable<Assignment> assignments)
        {
            Random rand = new Random();
            var query = from s in students
                        from a in assignments
                        select new Grade { 
                            AssignmentId = a.Id,
                            StudentId = s.Id,
                            Name = $"{a.Name.Trim()}-{s.Name.Trim()}-Grade",
                            Result = ((float)Math.Round(rand.NextDouble() * 5, 2)),
                            Id = Guid.NewGuid().ToString() };

            return query;

        }
    }
}
