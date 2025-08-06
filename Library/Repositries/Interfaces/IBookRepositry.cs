using Library.Entities;

namespace Library.Repositries.Interfaces
{
    public interface IBookRepositry
    {
        Task create(Book book);
        Task<Book> GetBook(int id);
        Task<List<Book>> GetAllBooks();
        Task delet(int id);
        Task update(Book book);
    }
}
