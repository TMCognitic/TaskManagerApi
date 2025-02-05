using TaskManagerApi.Dal.Entities;

namespace TaskManagerApi.Dal.Repositories
{
    public interface ITacheRepository
    {
        IEnumerable<Tache> Get(int utilisateurId);
        Tache? Get(int id, int utilisateurId);
        void Insert(Tache tache);
        void Update(Tache tache);
        void ChangeStatus(Tache tache);
    }
}
