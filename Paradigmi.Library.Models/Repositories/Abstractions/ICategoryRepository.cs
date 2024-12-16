using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Repositories.Abstractions
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Book> GetBooks(string Name);
        Category Get(string Name);
    }
}
