using System.ComponentModel.DataAnnotations;

namespace Api.Model.Request
{
    public class AuthRequest
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
