using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Models.Requests
{
    public class DeleteCategoryRequest
    {
        public DeleteCategoryRequest(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
