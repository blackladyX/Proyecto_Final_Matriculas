﻿// <auto-generated />
using Matriculas.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Matriculas.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220519180533_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Matriculas.Web.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ClassSchedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CourseCost")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateInscripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InicialDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Matriculas.Web.Models.Inscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dateofbirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdStudent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("Matriculas.Web.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"), 1L, 1);

                    b.Property<string>("ArtisticArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dateofbirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherCellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherIdentification")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
