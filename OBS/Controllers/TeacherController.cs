using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBS.Business.TeacherManager;
using OBS.Entities.Tables;

namespace OBS.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherManager _teacher;
        public TeacherController(ITeacherManager  teacher)
        {
            _teacher = teacher;
        }

        public IActionResult Index()
        {
            List<Entities.Tables.Teacher> result = _teacher.Get();
            return View(result);
        } 
        public IActionResult Create()
        {
            var model =_teacher.GetCreateModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (base.TryValidateModel(teacher))//Eğer Veri Geldiyse Ekle
            {
                _teacher.Create(teacher);
                return RedirectToAction("Index");//Teacher yolla
            }
            return View(teacher);
        }

        public IActionResult Edit(Guid Id)
        {
            var teacher = _teacher.Get().Where(t => t.Id == Id).FirstOrDefault();
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Edit(Guid Id,Teacher teacher)
        {
            _teacher.Edit(teacher);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            var teacher = _teacher.Get().Where(t => t.Id == Id).FirstOrDefault();
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Delete(Guid Id,Teacher teacher)
        {
            teacher = _teacher.Get().Where(t => t.Id == Id).FirstOrDefault();
            _teacher.Delete(Id,teacher);
            return RedirectToAction("Index");
        }
    }
}
