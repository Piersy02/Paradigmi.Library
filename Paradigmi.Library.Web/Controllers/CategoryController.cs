using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Library.Application.Abstractions.Services;
using Paradigmi.Library.Application.Factories;
using Paradigmi.Library.Application.Models.Requests;

namespace Paradigmi.Library.Web.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddCategory([FromBody] AddCategoryRequest request)
        {
            if (_categoryService.AddCategory(request.Name))
                return Ok(ResponseFactory.WithSuccess($"Category {request.Name} Added with success"));
            else
                return BadRequest(ResponseFactory.WithError("Category already exists"));
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteCategory([FromBody] DeleteCategoryRequest request)
        {
            if (_categoryService.DeleteCategory(request.Name))
                return Ok(ResponseFactory.WithSuccess($"Category {request.Name} Deleted with success"));
            else
                return BadRequest(ResponseFactory.WithError("Category null or associated at a book"));
        }
    }
}