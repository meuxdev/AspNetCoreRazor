using System;
using System.Collections.Generic;


namespace AspNetCoreRazor.Models
{
    public class School : ObjetoEscuelaBase
    {
        public int CreationDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public SchoolType SchoolType { get; set; }

        public List<Course> Courses { get; set; }
    }
}
