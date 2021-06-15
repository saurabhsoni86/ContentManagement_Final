using ContactManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.DataAccess.Factory
{
    public class RepositoryFactory: DbContext
    {
        public RepositoryFactory(DbContextOptions<RepositoryFactory> options)
            : base(options) { }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<ContactNumbers> ContactNumbers { get; set; }
    }
}
