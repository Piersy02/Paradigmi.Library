using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Repositories.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Category> GetCategories(int Id);
        IEnumerable<Book> GetBooks(string? name, string? author, string? editor, DateTime? publicationDate, string? category, int pageNum, int pageSize, out int totalNum);
    }
}
