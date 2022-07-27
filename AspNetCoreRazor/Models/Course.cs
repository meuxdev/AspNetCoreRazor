using System;
using System.Collections.Generic;


namespace AspNetCoreRazor.Models
{
    public class Course:ObjetoEscuelaBase
    {
        public ScheduleType ScheduleType { get; set; }

        public List<Student> Students { get; set; }
            
        public List<Assignment> Assignments { get; set; }

        public string Address { get; set; }

        public string SchoolId { get; set; }

        public School School { get; set; }

    }
}