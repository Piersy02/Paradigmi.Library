using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Library.Models.Entities;

namespace Paradigmi.Library.Application.Models.Requests
{
    public class AddCategoryRequest
    {
        public AddCategoryRequest(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
