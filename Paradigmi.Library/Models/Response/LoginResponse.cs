using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Models.Response
{
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            this.Token = token;
        }
        public string Token { get; set; }
    }
}
