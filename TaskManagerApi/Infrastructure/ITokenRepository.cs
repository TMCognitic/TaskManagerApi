using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Infrastructure
{
    public interface ITokenRepository
    {
        string CreateToken(User user);
    }
}