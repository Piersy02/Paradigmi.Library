using Microsoft.Extensions.Options;
using Paradigmi.Library.Application.Options;
using Paradigmi.Library.Application.Token;
using Paradigmi.Library.Application.Abstractions.Services;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private TokenGenerator _tokenService;

        public UserService(IUserRepository userRepository, IOptions<JwtAuthenticationOption> jwtAuthOptions)
        {
            _userRepository = userRepository;
            _tokenService = new TokenGenerator(jwtAuthOptions);
        }

        public string LogIn(string email, string password)
        {
            if (_userRepository.CredentialControl(email, password))
                return _tokenService.CreateToken(_userRepository.GetUserByEmail(email));
            return String.Empty;
        }

        public bool SignIn(string name, string surname, string email, string password)
        {
            if (_userRepository.CheckEmail(email))
                return false;
            User user = new User(name, surname, email, password);
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return true;
        }
    }
}