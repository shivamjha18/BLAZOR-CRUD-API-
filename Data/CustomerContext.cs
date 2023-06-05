using crudapi.Model;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Data
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Customer>customers { get; set; }
    }
}
