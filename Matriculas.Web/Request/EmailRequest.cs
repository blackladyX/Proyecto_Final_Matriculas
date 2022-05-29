using System.ComponentModel.DataAnnotations;
namespace Matriculas.Web.Request
{
    public class EmailRequest
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }

}
