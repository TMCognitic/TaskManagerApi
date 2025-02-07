using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace TaskManagerApi.Domain.Commands
{
    public class ChangeTacheStatusCommand : ICommandDefinition
    {
        public int Id { get; }
        public string Status { get; }
        public int UtilisateurId { get; }

        public ChangeTacheStatusCommand(int id, string status, int utilisateurId)
        {
            Id = id;
            Status = status;
            UtilisateurId = utilisateurId;
        }
    }
}
