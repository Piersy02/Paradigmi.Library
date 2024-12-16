using Paradigmi.Library.Models.Context;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Controlla se l'email sia già presente nel Db
        /// </summary>
        /// <returns>True se è presente, False altrimenti</returns>
        public bool CheckEmail(string email)
        {
            if (_ctx.Users.Any(u => u.Email.Equals(email)))
                return true;
            return false;
        }

        /// <summary>
        /// Controlla che le credenziali inserite siano corrette 
        /// </summary>
        /// <returns>True se l'utente esiste, False altrimenti</returns>
        public bool CredentialControl(string email, string password)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
            return user != null;
        }

        /// <summary>
        /// Restituisce l'utente passata la mail
        /// </summary>
        public User GetUserByEmail(string email)
        {
            return _ctx.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
