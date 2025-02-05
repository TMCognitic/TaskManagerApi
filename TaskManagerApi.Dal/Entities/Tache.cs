namespace TaskManagerApi.Dal.Entities
{
    public class Tache
    {
        public int Id { get; set; }
        public required string Titre { get; set; }
        public DateTime DateCreation { get; set; }
        public string Status { get; set; } = "En Cours";
        public int UtilisateurId { get; set; }
    }
}
