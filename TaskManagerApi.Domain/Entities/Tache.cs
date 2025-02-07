namespace TaskManagerApi.Domain.Entities
{
    public class Tache
    {
        public int Id { get; }
        public string Titre { get; }
        public DateTime DateCreation { get; }
        public string Status { get; }
        public int UtilisateurId { get; }

        internal Tache(int id, string titre, DateTime dateCreation, string status, int utilisateurId)
        {
            Id = id;
            Titre = titre;
            DateCreation = dateCreation;
            Status = status;
            UtilisateurId = utilisateurId;
        }
    }
}
