    using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OBS.Entities.Tables;

namespace OBS.DAL.Orm.EFCore
{
    public class ObsContext:DbContext
    {
        public ObsContext(DbContextOptions<ObsContext> options)
      : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonForStudent>()
                .HasOne(sa => sa.Student)
                .WithMany(sa => sa.MyLessons)
                .HasForeignKey(sa => sa.StudentId);
            modelBuilder.Entity<Lesson>()
                .HasOne(sa => sa.Teacher)
                .WithMany(sa => sa.MeLessons)
                .HasForeignKey(sa => sa.TeacherId);
            modelBuilder.Entity<StudentExamGrade>()
              .HasOne(sa => sa.Student)
              .WithMany(sa => sa.MyExams)
              .HasForeignKey(sa => sa.StudentId);
        }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonForStudent> LessonForStudents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<StudentExamGrade>  StudentExamGrades { get; set; }
    }
}
