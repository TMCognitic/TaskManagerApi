using TaskManagerApi.Domain.Entities;
using Tools.CQS.Queries;

namespace TaskManagerApi.Domain.Queries
{
    public class GetTachesQuery : IQueryDefinition<IEnumerable<Tache>>
    {
        public int UtilisateurId { get; }

        public GetTachesQuery(int utilisateurId)
        {
            UtilisateurId = utilisateurId;
        }
    }
}
