using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBS.Business.LessonManager;
using OBS.Business.StudentManager;
using OBS.DAL.Orm.EFCore;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Business.LessonForStudentManager
{
    public class LessonForStudentManager : ILessonForStudentManager
    {
        private readonly IObsRepository<LessonForStudent> _repository;
        private readonly IStudentManager _student;
        private readonly ILessonManager _lesson;
        public LessonForStudentManager(
            IObsRepository<LessonForStudent> repository,
            IStudentManager student,
            ILessonManager lesson)
        {
            _repository = repository;
            _student = student;
            _lesson = lesson;
        }
        public LessonForStudent Create(LessonForStudent lesson)
        {
            _repository.Create(lesson);
            return lesson;
        }

        public LessonForStudent Edit(LessonForStudent model)
        {
            _repository.Update(model);
            return model;
        }

        public IQueryable<LessonForStudent> GetAll()
        {
            return _repository.GetQuery();
        }

        public LessonForStudentModel GetCreateModel()
        {
            return new LessonForStudentModel
            {
                LessonForStudent = new LessonForStudent
                {
                    Id = Guid.NewGuid()
                },
                LessonList = _lesson.GetSelectList(),
                StudentList = _student.GetSelectList()
            };
        }

        public LessonForStudentModel GetEditModel(LessonForStudent lfs)
        {
            return new LessonForStudentModel
            {
                LessonForStudent = new LessonForStudent
                {
                    Id = lfs.Id,
                },
                StudentList=_student.GetSelectList(),
                LessonList = _lesson.GetSelectList(),
            };
        }
        public LessonForStudent Delete(LessonForStudent lfs)
        {
            _repository.Delete(lfs);
            return lfs;
        }
    }
}
