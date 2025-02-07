using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools.CQS.Commands;

namespace TaskManagerApi.Domain.Commands
{
    public class UpdateTacheCommand : ICommandDefinition
    {
        public int Id { get; }
        public string Titre { get; }
        public string Status { get; }
        public int UtilisateurId { get; }

        public UpdateTacheCommand(int id, string titre, string status, int utilisateurId)
        {
            Id = id;
            Titre = titre;
            Status = status;
            UtilisateurId = utilisateurId;
        }
    }
}
