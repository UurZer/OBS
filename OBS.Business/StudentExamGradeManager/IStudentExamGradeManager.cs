using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Business.StudentExamGradeManager
{
    public interface IStudentExamGradeManager
    {
        IQueryable<StudentExamGrade> All();
        StudentExamGrade Create(StudentExamGrade StudentExamGrade);
        StudentExamGradeModel GetCreateModel();
        StudentExamGradeModel GetEditModel(StudentExamGrade StudentExamGrade);
        StudentExamGrade Edit(StudentExamGrade StudentExamGrade);
        StudentExamGrade Delete(StudentExamGrade StudentExamGrade);
    }
}
