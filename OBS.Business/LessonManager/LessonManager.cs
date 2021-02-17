using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBS.Business.TeacherManager;
using OBS.Entities.Tables;
using OBS.Entities.Model;
using OBS.DAL.Orm.EFCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS.Business.StudentManager;

namespace OBS.Business.LessonManager
{
    public class LessonManager : ILessonManager
    {
        private readonly IObsRepository<Lesson> _repository;
        private readonly ITeacherManager _teacher;


        public LessonManager(IObsRepository<Lesson> repository,ITeacherManager teacher)
        {
            _repository = repository;
            _teacher = teacher;
        }
        public IQueryable<Lesson> All()
        {
            return _repository.GetQuery();
        }
        public Lesson Create(Lesson lesson)
        {
            _repository.Create(lesson);
            return lesson;
        }   
        public LessonModel GetCreateModel()
        {
            LessonModel model = new LessonModel();  
            model.Lesson = new Lesson() { LessonId = Guid.NewGuid() };
            model.TeacherList = _teacher.GetSelectList();
            return model;
        }
        public LessonModel GetEditModel(Lesson lesson)
        {
            LessonModel model = new LessonModel();
            model.Lesson = lesson;
            model.TeacherList =_teacher.GetSelectList();
            return model;
        }
        public Lesson Edit(Guid Id,Lesson lesson)
        {
            _repository.Update(lesson);
            return lesson;
        }
        public List<SelectListItem> GetSelectList()
        {
            return _repository.GetQuery()
                .Include(sa=>sa.Teacher)
                .Select(sa => new SelectListItem() {
                    Text =$"{sa.Code}-{sa.Name}#{sa.Teacher.NameSurname}",
                    Value=sa.LessonId.ToString()
                }).ToList();
        }
        public Lesson Delete(Lesson lesson)
        {
            _repository.Delete(lesson);
            return lesson;
        }
    }
}
