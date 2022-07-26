using Microsoft.AspNetCore.Mvc;
using CoursePractice.Models;
using System;
using System.Linq;

namespace CoursePractice.Controllers
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
            

            ViewBag.DinamicProp = "My name is jeff!";
            return View(school);
        }
    }
}
