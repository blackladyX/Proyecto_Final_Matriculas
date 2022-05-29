using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Matriculas.Web.Models
{
    public class Inscription
    {

        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string StudentFullName { get; set; }
        public string IdStudent { get; set; }
        public string Dateofbirth { get; set; }
        public string StudentAddress { get; set; }
        public string StudentCellPhone { get; set; }
        public string CourseName { get; set; }
       
       /* public ICollection<Product> Products { get; set; }
        /[DisplayName("Course Code")]
          /*public int CourseCode => Courses == null ? 0 : Courses.Count;*/


    }
}