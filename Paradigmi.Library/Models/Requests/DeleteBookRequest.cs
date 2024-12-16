using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Models.Requests
{
    public class DeleteBookRequest
    {
        public DeleteBookRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
