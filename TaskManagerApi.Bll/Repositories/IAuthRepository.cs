using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Bll.Repositories
{
    public interface IAuthRepository
    {
        Utilisateur? Login(string email, string password);
        void Register(Utilisateur user);
    }
}
