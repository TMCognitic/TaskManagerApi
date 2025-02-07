using System.Data;
using TaskManagerApi.Domain.Entities;

namespace TaskManagerApi.Domain.Mappers
{
    internal static partial class Mappers
    {
        public static Utilisateur ToUser(this IDataRecord record)
        {
            return new Utilisateur((int)record["Id"],
                (string)record["Nom"],
                (string)record["Prenom"],
                (string)record["Email"]);
        }
    }
}
