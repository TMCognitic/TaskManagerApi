using System.Data;
using TaskManagerApi.Domain.Entities;

namespace TaskManagerApi.Domain.Mappers
{
    internal static partial class Mappers
    {
        public static Tache ToTache(this IDataRecord record)
        {
            return new Tache((int)record["Id"], (string)record["Titre"], (DateTime)record["DateCreation"], (string)record["Status"], (int)record["UtilisateurId"]);
        }
    }
}
