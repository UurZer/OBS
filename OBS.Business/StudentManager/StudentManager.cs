using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.DAL.Orm.EFCore;
using OBS.Entities.Tables;

namespace OBS.Business.StudentManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IObsRepository<Student> _repository;

        public StudentManager(IObsRepository<Student> repository)
        {
            _repository = repository;
        }
        public Student Create(Student student)
        {
            _repository.Create(student);
            return student;
        }

        public List<Student> Get()
        {
            return _repository.Get();
        }

        public string CreateStudentNumber()
        {
            bool created = false;
            while (created == false)
            {
                string number = $"{DateTime.Now.Year}{new Random().Next(10000, 99999)}";
                var query = _repository.Get().Where(sa => sa.StudentNumber.Equals(number)).ToList();
                if (query == null || query.Count() == 0)
                {
                    created = true;
                    return number;
                }
                else
                {
                    created = false;
                    continue;
                }
            }
            throw new NullReferenceException("Öğrenci numarası oluşturulamadı");

        }

        public Student GetCreateModel()
        {
            return new Student
            {
                StudentNumber = this.CreateStudentNumber(), 
                RegiteredDate = DateTime.Now,
            };
        }

        public List<SelectListItem> GetSelectList()
        {
            return _repository.Get()
                .Select(sa => new SelectListItem()
                {
                    Text = $"{sa.StudentNumber} - {sa.NameSurname} - {sa.IsActive}",
                    Value = sa.Id.ToString()
                }).ToList();
        }

        public Student Edit(Student student)
        {
            _repository.Update(student);
            return student;
        }

        public Student Delete(Student student)
        {
            _repository.Delete(student);
            return student;
        }
    }
}
