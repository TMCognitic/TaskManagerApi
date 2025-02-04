namespace TaskManagerApi.Bll.Entities
{
    public class User
    {
        public int Id { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string? Passwd { get; internal set; }

        private User(string nom, string prenom, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }

        public User(string nom, string prenom, string email, string passwd)
            : this(nom, prenom, email)
        {
            Passwd = passwd;
        }

        internal User(int id, string nom, string prenom, string email)
            : this(nom, prenom, email)
        {
            Id = id;
        }
    }

}
