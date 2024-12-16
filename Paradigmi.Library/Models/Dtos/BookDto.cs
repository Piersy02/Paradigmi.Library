using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Models.Dtos
{
    public class BookDto
    {
        public int IdBook { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Editor { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; } = DateTime.MinValue;
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        public BookDto(Book book)
        {
            IdBook = book.IdBook;
            Name = book.Name;
            Author = book.Author;
            Editor = book.Editor;
            PublicationDate = book.PublicationDate;
            Categories = book.Categories;
        }
    }
}
