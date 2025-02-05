using BStorm.Tools.Database;
using System.Data.Common;
using TaskManagerApi.Dal.Entities;
using TaskManagerApi.Dal.Mappers;
using TaskManagerApi.Dal.Repositories;

namespace TaskManagerApi.Dal.Services
{
    public class TacheService : ITacheRepository
    {
        private readonly DbConnection _dbConnection;

        public TacheService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public void ChangeStatus(Tache tache)
        {
            _dbConnection.ExecuteNonQuery("[AppUser].[ChangeTacheStatus]", true, new { tache.Id, tache.Status, tache.UtilisateurId });
        }

        public IEnumerable<Tache> Get(int utilisateurId)
        {
            return _dbConnection.ExecuteReader("[AppUser].[GetTaches]", dr => dr.ToTache(), true, new { utilisateurId });
        }

        public Tache? Get(int id, int utilisateurId)
        {
            return _dbConnection.ExecuteReader("[AppUser].[GetTacheById]", dr => dr.ToTache(), true, new { id, utilisateurId }).SingleOrDefault();
        }

        public void Insert(Tache tache)
        {
            _dbConnection.ExecuteNonQuery("[AppUser].[CreateTache]", true, new { tache.Titre, tache.UtilisateurId });
        }

        public void Update(Tache tache)
        {
            _dbConnection.ExecuteNonQuery("[AppUser].[UpdateTache]", true, new { tache.Id, tache.Titre, tache.Status, tache.UtilisateurId });
        }
    }
}
