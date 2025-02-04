namespace TaskManagerApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
