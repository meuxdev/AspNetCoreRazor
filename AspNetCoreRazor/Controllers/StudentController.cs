﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRazor.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspNetCoreRazor.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _schoolContext;

        public StudentController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _schoolContext.Students.FirstOrDefaultAsync(); // returning the first student
            return View(students);
        }

        public IActionResult All()
        {
            var students = _schoolContext.Students.ToList();
            ViewBag.Date = DateTime.Now;
            return View(students);
        }


    }
}
