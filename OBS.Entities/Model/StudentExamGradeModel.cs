using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Tables;

namespace OBS.Entities.Model
{
    public class StudentExamGradeModel
    {
        public StudentExamGrade StudentExamGrade { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> LessonList { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public double Average { get; set; }
    }
}
