using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Tables;

namespace OBS.Entities.Model
{
    public class LessonModel
    {
        public Lesson Lesson { get; set; }
        public List<SelectListItem> TeacherList { get; set; }

    }
}
