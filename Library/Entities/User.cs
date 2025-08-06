namespace Library.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string phone { get; set; }
        public bool isadmin { get; set; }

    }
}
