namespace Library.Entities
{
    public class BorrowedBooks
    {
        public int id { get; set; }
        public DateTime borrowedat { get; set; }

        public int bookId { get; set; }
        public virtual Book book { get; set; }

        public int userId { get; set; }
        public virtual User user { get; set; }
    }
}
