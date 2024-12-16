using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Library.Models.Entities;

namespace Paradigmi.Library.Application.Models.Requests
{
    public class GetBookRequest
    {
        public GetBookRequest(string? name, string? author, string? editor, DateTime? publicationDate, string? category, int from, int size)
        {
            this.Name = name;
            this.Author = author;
            this.Editor = editor;
            this.PublicationDate = publicationDate;
            this.Category = Category;
            this.From = from;
            this.Size = size;
        }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Editor { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? Category { get; set; }
        public int From { get; set; } // Indice di partenza (per esempio 0 per la prima pagina)
        public int Size { get; set; } // Numero di risultati per pagina

    }
}
