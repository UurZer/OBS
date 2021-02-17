using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OBS.Entities.Tables
{
    [Table("Tbl_ExamGrade", Schema = "Obs")]
    public class StudentExamGrade
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Student")]
        [DisplayName("Öğrenci Adı")]
        public Guid? StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Lesson")]
        [DisplayName("Ders Adı")]
        public Guid? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        [DisplayName("Ortalama")]
        public double Average { get; set; }

    }
}
