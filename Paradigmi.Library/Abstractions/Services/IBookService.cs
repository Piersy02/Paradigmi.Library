using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Library.Models.Entities;

namespace Paradigmi.Library.Application.Abstractions.Services
{
    public interface IBookService
    {
        //Crea un nuovo libro
        bool AddBook(string name, string author, string editor, DateTime publicationDate, HashSet<Category> categories);
        //Cancella un libro
        bool DeleteBook(int id);
        //Modifica un libro
        public bool EditBook(int id, string name, string author, string editor, DateTime date, HashSet<Category> categories);
        //Restituisce un elenco di libri che corrispondono ai criteri di ricerca forniti
        IEnumerable<Book> GetBooks(string? name, string? author, string? editor, DateTime? date, string? category, int pageNum, int pageSize, out int totalNum);
    }
}
