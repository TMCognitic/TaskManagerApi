using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace TaskManagerApi.Domain.Commands
{
    public class AddTacheCommand : ICommandDefinition
    {
        public string Titre { get; }
        public int UtilisateurId { get; }

        public AddTacheCommand(string titre, int utilisateurId)
        {
            Titre = titre;
            UtilisateurId = utilisateurId;
        }
    }
}
