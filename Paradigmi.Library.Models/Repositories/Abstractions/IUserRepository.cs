using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckEmail(string email);
        bool CredentialControl(string email, string password);
        User GetUserByEmail(string email);
    }
}
