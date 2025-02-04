using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Bll.Repositories
{
    public interface IAuthRepository
    {
        User? Login(string email, string password);
        void Register(User user);
    }
}
