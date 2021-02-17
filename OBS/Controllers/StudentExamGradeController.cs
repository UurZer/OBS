using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS.Business.StudentExamGradeManager;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Controllers
{
    public class StudentExamGradeController : Controller
    {
        private readonly IStudentExamGradeManager _studentExamGradeManager;

        public StudentExamGradeController(IStudentExamGradeManager studentExamGradeManager)
        {
            _studentExamGradeManager = studentExamGradeManager;
        }
        public IActionResult Index()
        {
            var result = _studentExamGradeManager.All().Include(sa => sa.Lesson).Include(sa => sa.Student).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            var model = _studentExamGradeManager.GetCreateModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(StudentExamGradeModel model)
        {
            if (base.TryValidateModel(model.StudentExamGrade))
            {
                _studentExamGradeManager.Create(model.StudentExamGrade);
                return RedirectToAction("Index");
            }
            var exModel = _studentExamGradeManager.GetCreateModel();

            model.LessonList = exModel.LessonList;
            model.StudentList = exModel.StudentList;
            return View(model);
        }

        public IActionResult Edit(Guid Id)
        {
            var result = _studentExamGradeManager.All().Where(x => x.Id == Id).FirstOrDefault();
            StudentExamGradeModel model = _studentExamGradeManager.GetEditModel(result);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StudentExamGradeModel model)
        {
            _studentExamGradeManager.Edit(model.StudentExamGrade);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            var result = _studentExamGradeManager.All().Where(x => x.Id == Id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(StudentExamGrade model)
        {
            _studentExamGradeManager.Delete(model);
            return RedirectToAction("Index");
        }
    }
}
