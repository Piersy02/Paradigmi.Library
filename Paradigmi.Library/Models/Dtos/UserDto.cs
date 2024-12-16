using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Models.Dtos
{
    public class UserDto
    {
        public UserDto(User user)
        {
            this.IdUser = user.IdUser;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Email = user.Email;
            this.Password = user.Password;
        }
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
