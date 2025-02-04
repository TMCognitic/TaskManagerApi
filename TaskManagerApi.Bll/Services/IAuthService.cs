using IDalAuthRepository = TaskManagerApi.Dal.Repositories.IAuthRepository;
using TaskManagerApi.Bll.Entities;
using TaskManagerApi.Bll.Repositories;
using TaskManagerApi.Bll.Mappers;

namespace TaskManagerApi.Bll.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IDalAuthRepository _authRepository;

        public AuthService(IDalAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User? Login(string email, string password)
        {
            return _authRepository.Login(email, password)?.ToBll();
        }

        public void Register(User user)
        {
            _authRepository.Register(user.ToDal());
        }
    }
}
