using Microsoft.AspNetCore.Mvc;
using AspNetCoreRazor.Models;
using System.Linq;

namespace AspNetCoreRazor.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolContext _context;

        public SchoolController(SchoolContext context)
        {
            _context = context; // injecting the context
        }

        public IActionResult Index()
        {
            var school = _context.Schools.FirstOrDefault();
            //var school = new Escuela()
            //{
            //    UniqueId = Guid.NewGuid().ToString(),
            //    AñoDeCreación = 2005,
            //    Nombre = "Platzi",
            //    Pais = "Colombia",
            //    Dirección = "Random Direccion.",
            //    Ciudad = "Bogota",
            //    TipoEscuela = TiposEscuela.Online
            //};

            ViewBag.DinamicProp = "My name is jeff!";
            return View(school);
        }
    }
}
