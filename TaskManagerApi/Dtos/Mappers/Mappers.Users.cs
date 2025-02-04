using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Dtos.Mappers
{
    public static class Mappers
    {
        public static UserDto ToUserDto(this User entity, string token)
        {
            return new UserDto()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Token = token,
            };
        }
    }
}
