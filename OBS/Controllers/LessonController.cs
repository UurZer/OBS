using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS.Business.LessonManager;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonManager _lesson;
        public LessonController(ILessonManager lesson)
        {
            _lesson = lesson;
        }
        public IActionResult Index()
        {
            var result = _lesson.All().Include(sa => sa.Teacher).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            var model = _lesson.GetCreateModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(LessonModel model)
        {
            if(base.TryValidateModel(model.Lesson))
            {
                _lesson.Create(model.Lesson);
                return RedirectToAction("Index");
            }
            return View(model);   
        }
        public IActionResult Edit(Guid Id)
        {
            var lesson = _lesson.All().Where(l => l.LessonId == Id).FirstOrDefault();
            var model = _lesson.GetEditModel(lesson);
            return View(model);    
        }
        [HttpPost]
        public IActionResult Edit(Guid Id,Lesson lesson)
        {
            _lesson.Edit(Id,lesson);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid Id)
        {
            var lesson = _lesson.All().Where(l => l.LessonId== Id).FirstOrDefault();
            return View(lesson);
        }
        [HttpPost]
        public IActionResult Delete(Guid Id, Lesson lesson)
        {
            lesson = _lesson.All().Where(l => l.LessonId == Id).FirstOrDefault();
            _lesson.Delete(lesson);
            return RedirectToAction("Index");
        }
    }
}
