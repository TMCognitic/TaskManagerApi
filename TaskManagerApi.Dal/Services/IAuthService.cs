using BStorm.Tools.Database;
using System.Data.Common;
using TaskManagerApi.Dal.Entities;
using TaskManagerApi.Dal.Mappers;
using TaskManagerApi.Dal.Repositories;

namespace TaskManagerApi.Dal.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly DbConnection _dbConnection;

        public AuthService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public User? Login(string email, string passwd)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("AppUser.Login", dr => dr.ToUser(), true, new { email, passwd }).SingleOrDefault();
        }

        public void Register(User user)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("AppUser.Register", true, new { user.Nom, user.Prenom, user.Email, user.Passwd });
            user.Passwd = null;
        }
    }
}
