using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Library.Application.Abstractions.Services;
using Paradigmi.Library.Application.Models.Requests;
using Paradigmi.Library.Application.Models.Response;
using Paradigmi.Library.Application.Models.Dtos;
using Paradigmi.Library.Application.Factories;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System.ComponentModel;

namespace Paradigmi.Library.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookService bookService, ICategoryRepository categoryRepository)
        {
            _bookService = bookService;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddBook([FromBody] AddBookRequest request)
        {
            var categories = GetCategories(request.Categories);
            if (_bookService.AddBook(request.Name, request.Author, request.Editor, request.PublicationDate, categories))
                return Ok(ResponseFactory.WithSuccess("Book added with success"));
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult EditBook([FromBody] EditBookRequest request)
        {
            var categories = GetCategories(request.Categories);
            if (_bookService.EditBook(request.Id, request.Name, request.Author, request.Editor, request.PublicationDate,categories))
                return Ok(ResponseFactory.WithSuccess($"Book with Id {request.Id} edited with success"));
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteBook([FromBody] DeleteBookRequest request)
        {
            if (_bookService.DeleteBook(request.Id))
                return Ok(ResponseFactory.WithSuccess($"Book with Id {request.Id} deleted with success"));
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("list")]
        public IActionResult GetBooks([FromBody] GetBookRequest request)
        {
            int totalCount = 0;
            var name = request.Name;
            var author = request.Author;
            var editor = request.Editor;
            var category = request.Category;

            // Handling empty or default strings
            if (string.IsNullOrEmpty(name) || name == "string")
            {
                name = null;
            }
            if (string.IsNullOrEmpty(author) || author == "string")
            {
                author = null;
            }
            if (string.IsNullOrEmpty(editor) || editor == "string")
            {
                editor = null;
            }
            if (string.IsNullOrEmpty(category) || category == "string")
            {
                category = null;
            }

            // Getting the books using the service
            var books = _bookService.GetBooks(name, author, editor, null, category, request.From, request.Size, out totalCount);

            // Preparing the response
            var response = new GetBookResponse();
            response.NumPags = (int)Math.Ceiling((double)totalCount / request.Size);
            response.Books = books.Select(b => new BookDto(b)).ToList();

            return Ok(ResponseFactory.WithSuccess(response));
        }
        private HashSet<Category> GetCategories(HashSet<string> categories)
        {
            var categoriesCollection = new HashSet<Category>();
            foreach (string cat in categories)
            {
                Category category = _categoryRepository.Get(cat);
                if (category != null)
                    categoriesCollection.Add(category);
            }
            return categoriesCollection;
        }
    }
}
