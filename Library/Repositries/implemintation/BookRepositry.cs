using Library.Data;
using Library.Entities;
using Library.Repositries.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositries.implemintation
{
    public class BookRepositry(LibraryDbContext context) : IBookRepositry
    {
        public async Task create(Book book)
        {
           await context.books.AddAsync(book);
           await context.SaveChangesAsync();

        }

        public async Task delet(int id)
        {
            var b = await context.books.FirstOrDefaultAsync(x => x.id == id);
            if(b!=null)
             context.books.Remove(b);
            await context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await context.books.ToListAsync();
        }

        public async Task<Book?> GetBook(int id)
        {
            return await context.books.FirstOrDefaultAsync(x=>x.id==id);
        }

        public async Task update(Book book)
        {
            var b =await GetBook(book.id);
            if(b!=null)
            {
                b.Title = book.Title;
                b.authorname = book.authorname;
            }
            await context.SaveChangesAsync();
        }
    }
}
