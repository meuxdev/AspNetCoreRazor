using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CoursePractice.Models;
using System.Collections.Generic;

namespace CoursePractice.Controllers
{
    public class StudentController: Controller
    {
        public IActionResult Index()
        {
            return View(new Alumno()
            {
                Nombre = "Alejandro Andrade",
                UniqueId = Guid.NewGuid().ToString(),
            });
        }

        public IActionResult All()
        {

            var listaAsignaturas = GenerateRandom();
            ViewBag.Date = DateTime.Now;

            return View(listaAsignaturas);
        }


        private IReadOnlyList<Alumno> GenerateRandom()
        {
            string[] name = { "Freddy", "Alex", "Jorge", "Josh", "Chris" };
            string[] middleName = { "Felix", "John", "Robert", "Samuel", "Rick" };
            string[] lastName = { "Ruiz", "Trump", "Toledo", "Herrera" };

            IEnumerable<Alumno> query = from n in name
                                        from mn in middleName
                                        from l in lastName
                                        select new Alumno { Nombre = n + mn + l, UniqueId = Guid.NewGuid().ToString() };

            return query.ToList<Alumno>();
        } 
    }
}
