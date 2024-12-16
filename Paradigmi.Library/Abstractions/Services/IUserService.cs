using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Library.Models.Entities;

namespace Paradigmi.Library.Application.Abstractions.Services
{
    public interface IUserService
    {
        public bool SignIn(string name, string surname, string email, string password); // se corretta restituisce true
        public string LogIn(string email, string password); // se corretta restituisce il token(stringa)
    }
}
