namespace test_api_paynau.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public DateTime Borndate { get; set; }
        public bool Enabled { get; set; }
    }
}
