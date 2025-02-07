using BStorm.Tools.Database;
using System.Data.Common;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Mappers;
using TaskManagerApi.Domain.Queries;
using TaskManagerApi.Domain.Repositories;

namespace TaskManagerApi.Domain.Services
{
    public class TacheService : ITacheRepository
    {
        private readonly DbConnection _dbConnection;

        public TacheService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public bool Execute(AddTacheCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUser].[CreateTache]", true, command);
                if (rows == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        public IEnumerable<Tache> Execute(GetTachesQuery query)
        {
            return _dbConnection.ExecuteReader("[AppUser].[GetTaches]", dr => dr.ToTache(), true, query);
        }

        public Tache? Execute(GetTacheByIdQuery query)
        {
            return _dbConnection.ExecuteReader("[AppUser].[GetTacheById]", dr => dr.ToTache(), true, query).SingleOrDefault();
        }

        public bool Execute(UpdateTacheCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUser].[UpdateTache]", true, command);

                if(rows == 1)
                    return true;
            }
            catch (Exception)
            {
            }
            
            return false;
        }

        public bool Execute(ChangeTacheStatusCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUser].[ChangeTacheStatus]", true, command);

                if (rows == 1)
                    return true;
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}
