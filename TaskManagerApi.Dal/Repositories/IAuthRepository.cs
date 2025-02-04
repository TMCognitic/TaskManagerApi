using TaskManagerApi.Dal.Entities;

namespace TaskManagerApi.Dal.Repositories
{
    public interface IAuthRepository
    {
        User? Login(string email, string password);
        void Register(User user);
    }
}
