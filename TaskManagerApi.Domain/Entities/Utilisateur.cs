namespace TaskManagerApi.Domain.Entities
{
    public class Utilisateur
    {
        public int Id { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        internal Utilisateur(int id, string nom, string prenom, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }
    }

}
