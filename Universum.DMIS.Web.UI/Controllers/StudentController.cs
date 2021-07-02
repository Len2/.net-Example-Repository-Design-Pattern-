using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Universum.DMIS.Application.DTOs;
using Universum.DMIS.Application.Services.Students;
using Universum.DMIS.Web.UI.Models.Students;

namespace Universum.DMIS.Web.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var model = _studentService.Get().Select(student => new StudentGetModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new StudentAddModel());
        }

        [HttpPost]
        public IActionResult Add(StudentAddModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _studentService.Add(PrepareStudentModel(model));
            return View();
        }

        private StudentModel PrepareStudentModel(StudentAddModel model)
        {
            return new StudentModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth
            };
        }
    }
}
