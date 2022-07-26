using System;
using Microsoft.AspNetCore.Mvc;
using CoursePractice.Models;
using System.Collections.Generic;

namespace CoursePractice.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(new Asignatura()
            {
                Nombre = "Programacion con .NET",
                UniqueId = Guid.NewGuid().ToString(),
            });
        }

        public IActionResult All()
        {

            var listaAsignaturas = new List<Asignatura>() {
                new Asignatura{
                    Nombre = "Matemáticas",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Educación Física",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Castellano",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Ciencias Naturales",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Nombre = "Programacion",
                    UniqueId = Guid.NewGuid ().ToString ()
                }
            };

            ViewBag.Date = DateTime.Now;

            return View(listaAsignaturas);
        }
    }
}
