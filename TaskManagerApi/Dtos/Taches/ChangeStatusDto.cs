using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Dtos.Taches
{
    public class ChangeStatusDto
    {
        [Required]
        [MaxLength(20)]
        [AllowedValues("En Cours", "Cloturée")]
        public required string Status { get; set; }
    }
}
