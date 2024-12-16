using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Entities
{
    public class Book
    {
        public Book() { }
        public Book(string Name, string Author, DateTime PublicationDate, string Editor, HashSet<Category> Categories)
        {
            this.Name = Name;
            this.Author = Author;
            this.Categories = Categories;
            this.PublicationDate = PublicationDate;
            this.Editor = Editor;
        }
        public int IdBook { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Editor { get; set; } = string.Empty;
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

    }
}
