using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Domain.Entities;
using Tools.CQS.Queries;

namespace TaskManagerApi.Domain.Queries
{
    public class GetTacheByIdQuery : IQueryDefinition<Tache?>
    {
        public int Id { get; }
        public int UtilisateurId { get; }

        public GetTacheByIdQuery(int id, int utilisateurId)
        {
            Id = id;
            UtilisateurId = utilisateurId;
        }
    }
}
