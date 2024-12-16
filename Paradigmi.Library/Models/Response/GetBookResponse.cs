using Paradigmi.Library.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Models.Response
{
    public class GetBookResponse
    {
        public List<BookDto> Books { get; set; } // Lista dei libri trovati
        public int NumPags { get; set; } // Numero totale di pagine

        public GetBookResponse(List<BookDto> books, int numPags)
        {
            Books = books;
            NumPags = numPags;
        }

        public GetBookResponse()
        {
            Books = new List<BookDto>();
            NumPags = 0;
        }

    }
}
