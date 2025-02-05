using System.Data;
using TaskManagerApi.Dal.Entities;

namespace TaskManagerApi.Dal.Mappers
{
    internal static partial class Mappers
    {
        public static Tache ToTache(this IDataRecord record)
        {
            return new Tache()
            {
                Id = (int)record["Id"],
                Titre = (string)record["Titre"],
                DateCreation = (DateTime)record["DateCreation"],
                Status = (string)record["Status"],
                UtilisateurId = (int)record["UtilisateurId"]
            };
        }
    }
}
