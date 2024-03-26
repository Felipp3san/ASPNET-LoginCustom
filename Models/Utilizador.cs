using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace LoginCustom.Models
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username é necessário.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage="Username deve possuir no mínimo 2 caracteres.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password é necessário.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage="Password deve possuir no mínimo 8 caracteres.")]
        public string Password { get; set; } = string.Empty;

        public bool isAdmin { get; set; } = false;
        public bool isActive { get; set; } = true;
    }
}