using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Queries;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

namespace TaskManagerApi.Domain.Repositories
{
    public interface ITacheRepository :
        ICommandHandler<AddTacheCommand>,
        ICommandHandler<UpdateTacheCommand>,
        ICommandHandler<ChangeTacheStatusCommand>,
        IQueryHandler<GetTachesQuery, IEnumerable<Tache>>,
        IQueryHandler<GetTacheByIdQuery, Tache>
    {
    }
}
