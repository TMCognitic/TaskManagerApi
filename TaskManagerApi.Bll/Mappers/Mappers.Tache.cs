using TaskManagerApi.Bll.Entities;
using DalTache = TaskManagerApi.Dal.Entities.Tache;


namespace TaskManagerApi.Bll.Mappers
{
    internal static partial class Mappers
    {
        internal static Tache ToBll(this DalTache entity)
        {
            return new Tache(entity.Id, entity.Titre, entity.DateCreation, entity.Status, entity.UtilisateurId);            
        }

        internal static DalTache ToDal(this Tache entity)
        {
            return new DalTache()
            {
                Id = entity.Id,
                Titre = entity.Titre,
                DateCreation = entity.DateCreation,
                Status = entity.Status,
                UtilisateurId = entity.UtilisateurId
            };
        }
    }
}
