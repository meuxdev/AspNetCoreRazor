using System;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRazor.Models;
using System.Collections.Generic;

namespace AspNetCoreRazor.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(new Asignatura()
            {
                Nombre = "Programacion con .NET",
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
