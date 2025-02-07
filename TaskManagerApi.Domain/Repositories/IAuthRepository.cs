
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Queries;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

namespace TaskManagerApi.Domain.Repositories
{
    public interface IAuthRepository : ICommandHandler<RegisterCommand>,
        IQueryHandler<LoginQuery, Utilisateur>
    {
    }
}
