using Microsoft.EntityFrameworkCore;
using Paradigmi.Library.Models.Context;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce la lista di categorie che appartengono a quel libro
        /// </summary>
        /// <param name="id">Id del libro</param>
        /// <returns>La lista di categorie</returns>
        public IEnumerable<Category> GetCategories(int Id)
        {
            return _ctx.Books
                .Where(w => w.IdBook == Id)
                .SelectMany(c => c.Categories)
                .ToList();
        }

        /// <summary>
        /// Restituisce una collezione di libri che combaciano coi criteri indicati
        /// </summary>
        /// <returns>La lista dei libri</returns>
        public IEnumerable<Book> GetBooks(string? name, string? author, string? editor, DateTime? publicationDate, string? category, int pageNum, int pageSize, out int totalNum)
        {
            var query = _ctx.Set<Book>().Include(c => c.Categories).AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.ToLower().Trim().Contains(name.ToLower().Trim()));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(x => x.Author.ToLower().Trim().Contains(author.ToLower().Trim()));

            if (publicationDate != null)
                query = query.Where(x => x.PublicationDate.Date.Equals(publicationDate.Value.Date));

            if (!string.IsNullOrEmpty(editor))
                query = query.Where(x => x.Editor.ToLower().Trim().Contains(editor.ToLower().Trim()));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(x => x.Categories.Any(c => c.Name.ToLower().Trim().Equals(category.ToLower().Trim())));

            totalNum = query.Count();
            return query.Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

    }
}