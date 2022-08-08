using System.ComponentModel.DataAnnotations;

namespace SalesSite.Web.Dtos
{
    public class LoginDto
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
