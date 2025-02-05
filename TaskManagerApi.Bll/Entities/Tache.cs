namespace TaskManagerApi.Bll.Entities
{
    public class Tache
    {
        public int Id { get; }
        public string Titre { get; set; }
        public DateTime DateCreation { get; }
        public string Status { get; set; } = "En Cours";
        public int UtilisateurId { get; }

        public Tache(string titre, int utilisateurId)
        {
            Titre = titre;
            UtilisateurId = utilisateurId;
        }

        internal Tache(int id, string titre, DateTime dateCreation, string status, int utilisateurId)
            : this(titre, utilisateurId)
        {
            Id = id;
            DateCreation = dateCreation;
            Status = status;
        }
    }
}
