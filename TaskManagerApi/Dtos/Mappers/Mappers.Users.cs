using TaskManagerApi.Bll.Entities;
using TaskManagerApi.Dtos.Utilisateurs;

namespace TaskManagerApi.Dtos.Mappers
{
    public static class Mappers
    {
        public static UtilisateurDto ToUserDto(this Utilisateur entity)
        {
            return new UtilisateurDto()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email
            };
        }
    }
}
