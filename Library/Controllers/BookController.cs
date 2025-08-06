using AutoMapper;
using Library.DTO;
using Library.Entities;
using Library.Repositries.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class BookController(IBookRepositry book,IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await book.GetBook(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await book.GetAllBooks());
        }
        [HttpPost]
        public async Task<IActionResult>  Create(bookdto dto)
        {
            var b = mapper.Map<Book>(dto);await book.create(b);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> update(Book book1)
        {
            await book.update(book1);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await book.delet(id);
            return Ok();
        }
    }
}
