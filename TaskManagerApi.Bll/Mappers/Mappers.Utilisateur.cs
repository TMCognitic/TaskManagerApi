using DalUtilisateur = TaskManagerApi.Dal.Entities.Utilisateur;
using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Bll.Mappers
{
    internal static partial class Mappers
    {
        public static DalUtilisateur ToDal(this Utilisateur entity)
        {
            return new DalUtilisateur() { 
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Passwd = entity.Passwd
            };
        }

        public static Utilisateur ToBll(this DalUtilisateur entity)
        {
            return new Utilisateur(entity.Id, entity.Nom, entity.Prenom, entity.Email);
        }
    }
}
