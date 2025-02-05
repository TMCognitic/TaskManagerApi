using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Dtos.Taches
{
    public class UpdateTacheDto
    {
        [Required]
        [MaxLength(255)]
        public required string Titre { get; set; }

        [Required]
        [MaxLength(20)]
        [AllowedValues("En Cours", "Cloturée")]
        public required string Status { get; set; }
    }
}
