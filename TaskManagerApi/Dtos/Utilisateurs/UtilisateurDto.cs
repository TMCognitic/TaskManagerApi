namespace TaskManagerApi.Dtos.Utilisateurs
{
    public class UtilisateurDto
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public string Token { get; set; } = default!;
    }
}
