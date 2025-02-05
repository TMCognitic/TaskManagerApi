using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Bll.Repositories
{
    public interface ITacheRepository
    {
        IEnumerable<Tache> Get(int utilisateurId);
        void Insert(Tache tache);
        Tache? Get(int id, int utilisateurId);
        void Update(int id, Tache tache);
        void ChangeStatus(int id, string status, int utilisateurId);
    }
}
