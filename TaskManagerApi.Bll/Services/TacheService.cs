using DalTache = TaskManagerApi.Dal.Entities.Tache;
using IDalTacheRepository = TaskManagerApi.Dal.Repositories.ITacheRepository;
using TaskManagerApi.Bll.Entities;
using TaskManagerApi.Bll.Repositories;
using TaskManagerApi.Bll.Mappers;

namespace TaskManagerApi.Bll.Services
{
    public class TacheService : ITacheRepository
    {
        private readonly IDalTacheRepository _tacheRepository;

        public TacheService(IDalTacheRepository tacheRepository)
        {
            _tacheRepository = tacheRepository;
        }

        public void ChangeStatus(int id, string status, int utilisateurId)
        {
            _tacheRepository.ChangeStatus(new DalTache() { Id = id, Status = status, UtilisateurId = utilisateurId, Titre = string.Empty });
        }

        public IEnumerable<Tache> Get(int utilisateurId)
        {
            return _tacheRepository.Get(utilisateurId).Select(t => t.ToBll());
        }

        public Tache? Get(int id, int utilisateurId)
        {
            return _tacheRepository.Get(id, utilisateurId)?.ToBll();
        }

        public void Insert(Tache tache)
        {
            _tacheRepository.Insert(tache.ToDal());
        }

        public void Update(int id, Tache tache)
        {
            DalTache dt = tache.ToDal();
            dt.Id = id;

            _tacheRepository.Update(dt);
        }
    }
}
