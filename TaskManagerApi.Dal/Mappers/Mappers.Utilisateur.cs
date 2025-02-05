using System.Data;
using TaskManagerApi.Dal.Entities;

namespace TaskManagerApi.Dal.Mappers
{
    internal static partial class Mappers
    {
        public static Utilisateur ToUser(this IDataRecord record)
        {
            return new Utilisateur()
            {
                Id = (int)record["Id"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"],
                Email = (string)record["Email"]
            };
        }
    }
}
