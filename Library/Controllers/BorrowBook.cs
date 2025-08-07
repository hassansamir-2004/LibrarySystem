using Library.Data;
using Library.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowBook(LibraryDbContext context) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> borrowbook(int bookid)
        {
            var book =await context.books.FirstOrDefaultAsync(x => x.id == bookid);var userid=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(book!=null&&book.IsAvalable==true)
            {
                
                    BorrowedBooks borrowed = new BorrowedBooks
                    {
                        userId = userid,
                        bookId = bookid,
                        borrowedat = DateTime.Now
                    };
                    book.IsAvalable = false;
                    await context.borrowedBooks.AddAsync(borrowed);
                    await context.SaveChangesAsync();
                    return Ok("borrow book");

                
            }
            return Ok("user or book is notfound");
        }
    }
}
