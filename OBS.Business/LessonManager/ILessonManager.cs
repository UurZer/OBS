using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBS.Entities.Tables;
using OBS.Entities.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OBS.Business.LessonManager
{
    public interface ILessonManager
    {
        IQueryable<Lesson> All();
        Lesson Create(Lesson lesson);
        LessonModel GetCreateModel();
        LessonModel GetEditModel(Lesson lesson);
        Lesson Edit(Guid Id,Lesson lesson);
        Lesson Delete(Lesson lesson);
        List<SelectListItem> GetSelectList();
    }
}
