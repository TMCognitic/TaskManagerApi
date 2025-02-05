using TaskManagerApi.Dal.Entities;

namespace TaskManagerApi.Dal.Repositories
{
    public interface IAuthRepository
    {
        Utilisateur? Login(string email, string password);
        void Register(Utilisateur user);
    }
}
