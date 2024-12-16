using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Library.Models.Entities;

namespace Paradigmi.Library.Application.Models.Requests
{
    public class SignInRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User ToEntity()
        {
            return new User(Name, Surname, Email, Password);
        }
    }
}
