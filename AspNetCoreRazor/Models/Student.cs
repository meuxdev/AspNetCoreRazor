using System.Collections.Generic;

namespace AspNetCoreRazor.Models
{
    public class Student: ObjetoEscuelaBase
    {
        public List<Grade> Grades { get; set; }

        public string CourseId  { get; set; }

        public Course Course { get; set; }
    }
}