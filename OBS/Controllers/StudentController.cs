using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBS.Business.LoginManager;
using OBS.Business.StudentManager;
using OBS.Entities.Tables;

namespace OBS.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentManager _student;
        public StudentController(IStudentManager student)
        {
            _student = student;
        }

        public IActionResult Index()
        {
            var result = _student.Get();
                return View(result);
        }
        public IActionResult Create()
        {
            Student model = _student.GetCreateModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (base.TryValidateModel(model))
            {
                _student.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Edit(Guid Id)
        {
            var student = _student.Get().Where(l => l.Id == Id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Guid Id, Student student)
        {
            _student.Edit(student);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(Guid Id)
        {
            var student = _student.Get().Where(l => l.Id == Id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Guid Id,Student student)
        {
            _student.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
