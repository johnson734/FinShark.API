using FinShark.API.Dtos.Category;
using FinShark.API.Helpers;
using FinShark.API.Interfaces;
using FinShark.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinShark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly ApiResponse _response;
        public CategoryController(ICategoryRepository repo)
        {
            this._repo = repo;
        }

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var data = await _repo.GetAllAsync(UserId());
            if (data == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.ErrorMessage.Add("No Data Found");
                return NotFound(_response);
            }

            _response.Result = data;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            var data = await _repo.GetByIdAsync(id, UserId());
            if (data == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.ErrorMessage.Add("No Data Found");
                return NotFound(_response);
            }
            _response.Result = data;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(CategoryCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                foreach (var errors in ModelState.Values)
                {
                    foreach (var error in errors.Errors)
                    {
                        _response.ErrorMessage.Add(error.ErrorMessage);
                    }
                }

                return BadRequest(_response);
            }
            Category category = new Category
            {
                Name = dto.Name,
                Type = dto.Type,
                ApplicationUserId = UserId()
            };

            await _repo.AddAsync(category);

            _response.Result = category;
            _response.StatusCode = HttpStatusCode.Created;

            return CreatedAtAction("GetById", new { id = category.CategoryId }, category);

        }




    }
}
