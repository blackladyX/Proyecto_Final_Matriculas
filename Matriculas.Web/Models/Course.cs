using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Matriculas.Web.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string InicialDate { get; set; }
        public string FinalDate { get; set; }
        public string Description { get; set; }
        public int CourseCost { get; set; }
        public string DateInscripcion { get; set; }
        public int Capacity { get; set; }
        public int Intensity { get; set; }
        public string ClassSchedule { get; set; }

        [JsonIgnore] //lo ignora en la respuesta json
        [NotMapped] //no se crea en la base de datos
        public int Id { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        [DisplayName("Teacher Identificaction")]
        public int TeacherIdentificaction => Teachers == null ? 0 : Teachers.Count;
    }
}
