using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Tables;

namespace OBS.Entities.Model
{
    public class LessonForStudentModel
    {
        public LessonForStudent LessonForStudent { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> LessonList { get; set; }

    }
}
