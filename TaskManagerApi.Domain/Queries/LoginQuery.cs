using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Domain.Entities;
using Tools.CQS.Queries;

namespace TaskManagerApi.Domain.Queries
{
    public class LoginQuery : IQueryDefinition<Utilisateur?>
    {
        public string Email { get; }
        public string Passwd { get; }

        public LoginQuery(string email, string passwd)
        {
            Email = email;
            Passwd = passwd;
        }
    }
}
