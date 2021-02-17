using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Model;
using OBS.Entities.Tables;

namespace OBS.Business.LessonForStudentManager
{
    public interface ILessonForStudentManager
    {
        IQueryable<LessonForStudent> GetAll();
        LessonForStudent Create(LessonForStudent model);
        LessonForStudent Edit(LessonForStudent model);
        LessonForStudentModel GetCreateModel();
        LessonForStudentModel GetEditModel(LessonForStudent lfs);
        LessonForStudent Delete(LessonForStudent lfs);
    }
}
