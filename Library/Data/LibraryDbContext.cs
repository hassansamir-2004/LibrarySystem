using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Book> books { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<BorrowedBooks> borrowedBooks { get; set; }
    }
}
