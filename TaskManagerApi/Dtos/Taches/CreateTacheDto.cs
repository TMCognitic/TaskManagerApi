using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Dtos.Taches
{
    public class CreateTacheDto
    {
        [Required]
        [MaxLength(255)]
        public required string Titre { get; set; }
    }
}
