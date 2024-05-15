using LabAPI.Data;
using LabAPI.Models.DTO;
using LabAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(AppDbContext dbContext, IAuthorRepository
       authorRepository)
        {
            _dbContext = dbContext;
            _authorRepository = authorRepository;
        }
        [HttpGet("get-all-author")]
        public IActionResult GetAllAuthor()
        {
            var allAuthors = _authorRepository.GellAllAuthors();
            return Ok(allAuthors);
        }
        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var authorWithId = _authorRepository.GetAuthorById(id);
            return Ok(authorWithId);
        }
        [HttpPost("add-author")]
        public IActionResult AddAuthors([FromBody] AddAuthorRequestDTO
       addAuthorRequestDTO)
        {
            var authorAdd = _authorRepository.AddAuthor(addAuthorRequestDTO);
            return Ok();
        }
        [HttpPut("update-author-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] AuthorNoIdDTO
       authorDTO)
        {
            var authorUpdate = _authorRepository.UpdateAuthorById(id, authorDTO);
            return Ok(authorUpdate);
        }
        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var authorDelete = _authorRepository.DeleteAuthorById(id);
            return Ok();
        }

    }
}
