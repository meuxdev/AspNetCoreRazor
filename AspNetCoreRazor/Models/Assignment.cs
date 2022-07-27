using System.Collections.Generic;

namespace AspNetCoreRazor.Models
{
    public class Assignment:ObjetoEscuelaBase
    {
        public string CourseId { get; set; }

        public Course Course { get; set; }

        public List<Grade> Grades { get; set; }

    }
}