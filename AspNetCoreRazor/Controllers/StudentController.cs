using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRazor.Models;
using System.Collections.Generic;

namespace AspNetCoreRazor.Controllers
{
    public class StudentController: Controller
    {
        public IActionResult Index()
        {
            return View(new Alumno()
            {
                Nombre = "Alejandro Andrade",
                Id = Guid.NewGuid().ToString(),
            });
        }

        public IActionResult All()
        {

            var listaAsignaturas = new List<Asignatura>();
            ViewBag.Date = DateTime.Now;

            return View(listaAsignaturas);
        }


            }
}
