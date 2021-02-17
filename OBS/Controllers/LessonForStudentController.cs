using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS.Business.LessonForStudentManager;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Controllers
{
    public class LessonForStudentController : Controller
    {
        private readonly ILessonForStudentManager _lfs;

        public LessonForStudentController(ILessonForStudentManager lfs)
        {
            _lfs = lfs;
        }
        public IActionResult Index()
        {
            var result = _lfs.GetAll().Include(sa => sa.Lesson).Include(sa => sa.Student).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            var model = _lfs.GetCreateModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(LessonForStudentModel model)
        {
            if (base.TryValidateModel(model.LessonForStudent))
            {
                _lfs.Create(model.LessonForStudent);
                return RedirectToAction("Index");
            }
            var exModel = _lfs.GetCreateModel();

            model.LessonList = exModel.LessonList;
            model.StudentList = exModel.StudentList;
            return View(model);
        }

        public IActionResult Edit(Guid Id)
        {
            var lfs = _lfs.GetAll().Where(l => l.Id == Id).FirstOrDefault();
            var model = _lfs.GetEditModel(lfs);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(LessonForStudentModel model)
        {
            _lfs.Edit(model.LessonForStudent);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            var lfs = _lfs.GetAll().Where(l => l.Id == Id).FirstOrDefault();
            return View(lfs);
        }

        [HttpPost]
        public IActionResult Delete(Guid Id,LessonForStudent lfs)
        {
            lfs = _lfs.GetAll().Where(l => l.Id == Id).FirstOrDefault();
            _lfs.Delete(lfs);
            return RedirectToAction("Index");
        }
    }
}
