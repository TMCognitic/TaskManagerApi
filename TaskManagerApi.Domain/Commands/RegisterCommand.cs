using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace TaskManagerApi.Domain.Commands
{
    public class RegisterCommand : ICommandDefinition
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string Email { get; }
        public string Passwd { get;}

        public RegisterCommand(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }
    }
}
