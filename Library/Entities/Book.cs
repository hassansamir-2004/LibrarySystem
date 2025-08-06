namespace Library.Entities
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool IsAvalable { get; set; } = true;
        public string authorname { get; set; }
    }
}
