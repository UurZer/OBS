using System;
using System.Collections.Generic;
using System.Text;
using OBS.Entities.Tables;
using System.Linq;
using OBS.DAL.Orm.EFCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OBS.Business.TeacherManager
{
    public class TeacherManager : ITeacherManager
    {
        private readonly IObsRepository<Teacher> _repository;
        public TeacherManager(IObsRepository<Teacher> repository)
        {
            _repository = repository;
        }
        public Teacher Create(Teacher teacher)
        {
            _repository.Create(teacher);
             return teacher;
        }

        public List<Teacher> Get()
        {
            return _repository.Get();
        }
        public Teacher GetCreateModel()
        {
            return new Teacher
            {
                Id = Guid.NewGuid(),
            };
        }

        public List<SelectListItem> GetSelectList()
        {
            List<SelectListItem> result = _repository.Get()
                .Select(sa => new SelectListItem() {
                    Text = $"{sa.Tag}{sa.NameSurname}",
                    Value = sa.Id.ToString(),
                }).ToList();
            return result;
        }

        public Teacher Edit(Teacher teacher)
        {
            _repository.Update(teacher);
            return teacher;
        }

        public Teacher Delete(Guid Id,Teacher teacher)
        {
            _repository.Delete(teacher);
            return teacher;
        }
    }
}
