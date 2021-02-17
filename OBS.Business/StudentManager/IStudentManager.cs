using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Tables;

namespace OBS.Business.StudentManager
{
    public interface IStudentManager
    {
        List<Student> Get();
        Student Create(Student student);
        Student GetCreateModel();
        string CreateStudentNumber();
        Student Edit(Student student);
        Student Delete(Student student);
        List<SelectListItem> GetSelectList();
    }
}
