using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Business.LessonManager;
using OBS.Business.StudentManager;
using OBS.DAL.Orm.EFCore;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Business.StudentExamGradeManager
{
    public class StudentExamGradeManager:IStudentExamGradeManager
    {
        private readonly IObsRepository<StudentExamGrade> _repository;
        private readonly IStudentManager _student;
        private readonly ILessonManager _lesson;
        public StudentExamGradeManager(
            IObsRepository<StudentExamGrade> repository,
            IStudentManager student,
            ILessonManager lesson)
        {
            _repository = repository;
            _student = student;
            _lesson = lesson;
        }

        public IQueryable<StudentExamGrade> All()
        {
            return _repository.GetQuery();
        }

        public StudentExamGrade Create(StudentExamGrade StudentExamGrade)
        {
            _repository.Create(new StudentExamGrade()
            {
                Id = StudentExamGrade.Id,
                LessonId = StudentExamGrade.LessonId,
                StudentId = StudentExamGrade.StudentId,
                Vize = StudentExamGrade.Vize,
                Final = StudentExamGrade.Final,
                Average = (StudentExamGrade.Final + StudentExamGrade.Vize) / 2,
            });
            StudentExamGrade.Average = StudentExamGrade.Vize + StudentExamGrade.Final / 2;
            return StudentExamGrade;
        }

        public StudentExamGrade Delete(StudentExamGrade StudentExamGrade)
        {
            _repository.Delete(StudentExamGrade);
            return StudentExamGrade;
        }

        public StudentExamGrade Edit(StudentExamGrade StudentExamGrade)
        {
            _repository.Update(new StudentExamGrade()
            {
                Id = StudentExamGrade.Id,
                LessonId = StudentExamGrade.LessonId,
                StudentId = StudentExamGrade.StudentId,
                Vize = StudentExamGrade.Vize,
                Final = StudentExamGrade.Final,
                Average = (StudentExamGrade.Final + StudentExamGrade.Vize) / 2,
            });
            StudentExamGrade.Average = StudentExamGrade.Vize + StudentExamGrade.Final / 2;
            return StudentExamGrade;
        }

        public StudentExamGradeModel GetCreateModel()
        {
            return new StudentExamGradeModel
            {
                StudentExamGrade = new StudentExamGrade
                {
                    Id = Guid.NewGuid()
                },
                LessonList = _lesson.GetSelectList(),
                StudentList = _student.GetSelectList()
            };
        }

        public StudentExamGradeModel GetEditModel(StudentExamGrade StudentExamGrade)
        {
            return new StudentExamGradeModel
            {
                StudentExamGrade = new StudentExamGrade
                {
                    Id = StudentExamGrade.Id,
                },
                LessonList = _lesson.GetSelectList(),
                StudentList = _student.GetSelectList()
            };
        }
    }
}
