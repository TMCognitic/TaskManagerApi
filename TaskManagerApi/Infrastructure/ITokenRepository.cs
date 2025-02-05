using TaskManagerApi.Dtos.Utilisateurs;

namespace TaskManagerApi.Infrastructure
{
    public interface ITokenRepository
    {
        UtilisateurDto? Utilisateur { get; }
        void ApplyToken(UtilisateurDto user);
    }
}