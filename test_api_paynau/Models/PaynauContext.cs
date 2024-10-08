using Microsoft.EntityFrameworkCore;

namespace test_api_paynau.Models
{
    public class PaynauContext : DbContext
    {

        public PaynauContext(DbContextOptions<PaynauContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
