using Microsoft.EntityFrameworkCore;
using Paradigmi.Library.Models.Context;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Paradigmi.Library.Models.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce una lista di libri che appartengono ad una categoria
        /// </summary>
        /// <param name="Nome">Nome della categoria</param>
        /// <returns>Lista di libri appartenenti dalla categoria</returns>
        public IEnumerable<Book> GetBooks(string Name)
        {
            return _ctx.Books
                .Where(w => w.Categories.Any(c => c.Name.ToLower().Trim() == Name.ToLower().Trim()))
                .ToList();
        }

        // faccio overload del metodo per evitare che si siano categorie con lo stesso nome ma lettere maiuscole/minuscole
        public Category Get(string name)
        {
            var category = _ctx.Categories.FirstOrDefault(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
            if (category != null)
                return _ctx.Categories.Find(category.Name);
            else
                return null;
        }
    }
}