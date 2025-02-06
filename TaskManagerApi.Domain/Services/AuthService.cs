
using BStorm.Tools.Database;
using System.Data.Common;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Queries;
using TaskManagerApi.Domain.Repositories;
using TaskManagerApi.Domains.Mappers;

namespace TaskManagerApi.Domain.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly DbConnection _dbConnection;

        public AuthService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public bool Execute(RegisterCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("AppUser.Register", true, command);

                if(rows == 1)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Utilisateur? Execute(LoginQuery query)
        {
            return _dbConnection.ExecuteReader("AppUser.Login", dr => dr.ToUser(), true, query).SingleOrDefault();
        }
    }
}
