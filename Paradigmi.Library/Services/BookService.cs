using Paradigmi.Library.Application.Abstractions.Services;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Paradigmi.Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public bool AddBook(string name, string author, string editor, DateTime date, HashSet<Category> categories)
        {
            Book book = new Book(name, author, date, editor, categories);
            _bookRepository.Add(book);
            _bookRepository.SaveChanges();
            return true;
        }

        public bool DeleteBook(int Id)
        {
            if (Id > 0 && _bookRepository.Get(Id) != null)
            {
                _bookRepository.Delete(Id);
                _bookRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Book> GetBooks(string? name, string? author, string? editor, DateTime? date, string? category, int pageNum, int pageSize, out int totalNum)
        {
            return _bookRepository.GetBooks(name, author, editor, date, category, pageNum, pageSize, out totalNum);
        }

        public bool EditBook(int id, string name, string author, string editor, DateTime date, HashSet<Category> categories)
        {
            if (_bookRepository.Get(id) == null)
                return false;
            Book book = _bookRepository.Get(id);
            book.Name = name;
            book.Author = author;
            book.Editor = editor;
            book.PublicationDate = date;
            book.Categories = categories;
            _bookRepository.Edit(book);
            _bookRepository.SaveChanges();
            return true;

        }
    }
}
