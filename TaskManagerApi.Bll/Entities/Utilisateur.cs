namespace TaskManagerApi.Bll.Entities
{
    public class Utilisateur
    {
        public int Id { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string? Passwd { get; internal set; }

        private Utilisateur(string nom, string prenom, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }

        public Utilisateur(string nom, string prenom, string email, string passwd)
            : this(nom, prenom, email)
        {
            Passwd = passwd;
        }

        internal Utilisateur(int id, string nom, string prenom, string email)
            : this(nom, prenom, email)
        {
            Id = id;
        }
    }

}
