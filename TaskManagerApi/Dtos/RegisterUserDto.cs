using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Nom {  get; set; }
        [Required]
        [MaxLength(50)]
        public required string Prenom {  get; set; }
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public required string Email {  get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public required string Passwd {  get; set; }
    }
}
