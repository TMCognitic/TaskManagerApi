using DalUser = TaskManagerApi.Dal.Entities.User;
using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Bll.Mappers
{
    public static partial class Mappers
    {
        public static DalUser ToDal(this User entity)
        {
            return new DalUser() { 
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Passwd = entity.Passwd
            };
        }

        public static User ToBll(this DalUser entity)
        {
            return new User(entity.Id, entity.Nom, entity.Prenom, entity.Email);
        }
    }
}
