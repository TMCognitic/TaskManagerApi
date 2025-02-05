using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Dtos.Utilisateurs
{
    public class LoginDto
    {
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public required string Passwd { get; set; }
    }
}
