﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBS.DAL.Orm.EFCore;

namespace OBS.DAL.Migrations
{
    [DbContext(typeof(ObsContext))]
    [Migration("20210113173952_ObsDB")]
    partial class ObsDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OBS.Entities.Tables.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LessonId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Tbl_Lessons","Obs");
                });

            modelBuilder.Entity("OBS.Entities.Tables.LessonForStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Tbl_Lessons_Student","Obs");
                });

            modelBuilder.Entity("OBS.Entities.Tables.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Tbl_Login","Obs");
                });

            modelBuilder.Entity("OBS.Entities.Tables.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("RegiteredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Students","Obs");
                });

            modelBuilder.Entity("OBS.Entities.Tables.StudentExamGrade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Average")
                        .HasColumnType("float");

                    b.Property<int>("Final")
                        .HasColumnType("int");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Vize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Tbl_ExamGrade","Obs");
                });

            modelBuilder.Entity("OBS.Entities.Tables.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tbl_Teacher","Obs");
                });

            modelBuilder.Entity("OBS.Entities.Tables.Lesson", b =>
                {
                    b.HasOne("OBS.Entities.Tables.Teacher", "Teacher")
                        .WithMany("MeLessons")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("OBS.Entities.Tables.LessonForStudent", b =>
                {
                    b.HasOne("OBS.Entities.Tables.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");

                    b.HasOne("OBS.Entities.Tables.Student", "Student")
                        .WithMany("MyLessons")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("OBS.Entities.Tables.StudentExamGrade", b =>
                {
                    b.HasOne("OBS.Entities.Tables.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");

                    b.HasOne("OBS.Entities.Tables.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
