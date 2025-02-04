using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Dal.Entities;

namespace TaskManagerApi.Dal.Mappers
{
    internal static class Mappers
    {
        public static User ToUser(this IDataRecord record)
        {
            return new User()
            {
                Id = (int)record["Id"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"],
                Email = (string)record["Email"]
            };
        }
    }
}
