
using BStorm.Tools.Database;
using System.Data.Common;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Queries;
using TaskManagerApi.Domain.Repositories;
using TaskManagerApi.Domain.Mappers;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

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

        public CommandResult Execute(RegisterCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("AppUser.Register", true, command);

                if (rows != 1)
                    return CommandResult.Failure("Nombre de lignes modifiée(s) invalide");

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }

        public QueryResult<Utilisateur> Execute(LoginQuery query)
        {
            try
            {
                Utilisateur? utilisateur = _dbConnection.ExecuteReader("AppUser.Login", dr => dr.ToUser(), true, query).SingleOrDefault();

                if (utilisateur is null)
                    return QueryResult<Utilisateur>.Failure("Email et mot de passe incorrecte");

                return QueryResult<Utilisateur>.Success(utilisateur);            
            }
            catch (Exception ex)
            {
                return QueryResult<Utilisateur>.Failure(ex.Message, ex);
            }
        }
    }
}
