namespace TaskManagerApi.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public string? Passwd { get; set; }
    }
}
