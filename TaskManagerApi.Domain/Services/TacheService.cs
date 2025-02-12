using BStorm.Tools.Database;
using System.Data.Common;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Mappers;
using TaskManagerApi.Domain.Queries;
using TaskManagerApi.Domain.Repositories;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

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

        public CommandResult Execute(AddTacheCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUser].[CreateTache]", true, command);
                if (rows != 1)
                {
                    return CommandResult.Failure("Somethihg Wrong");
                }

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }

        public QueryResult<IEnumerable<Tache>> Execute(GetTachesQuery query)
        {
            try
            {
                IEnumerable<Tache> taches = _dbConnection.ExecuteReader("[AppUser].[GetTaches]", dr => dr.ToTache(), true, query).ToList();
                return QueryResult<IEnumerable<Tache>>.Success(taches);
            }
            catch (Exception ex)
            {
                return QueryResult<IEnumerable<Tache>>.Failure(ex.Message, ex);
            }
        }

        public QueryResult<Tache> Execute(GetTacheByIdQuery query)
        {
            try
            {
                Tache? tache = _dbConnection.ExecuteReader("[AppUser].[GetTacheById]", dr => dr.ToTache(), true, query).SingleOrDefault();

                if (tache is null)
                    return QueryResult<Tache>.Failure("Not found");


                return QueryResult<Tache>.Success(tache);
            }
            catch (Exception ex)
            {
                return QueryResult<Tache>.Failure(ex.Message, ex);
            }
        }

        public CommandResult Execute(UpdateTacheCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUser].[UpdateTache]", true, command);

                if (rows != 1)
                {
                    return CommandResult.Failure("Somethihg Wrong");
                }

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }

        public CommandResult Execute(ChangeTacheStatusCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUser].[ChangeTacheStatus]", true, command);

                if (rows != 1)
                {
                    return CommandResult.Failure("Somethihg Wrong");
                }

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }
    }
}
