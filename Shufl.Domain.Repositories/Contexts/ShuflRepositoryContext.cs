using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;

namespace Shufl.Domain.Repositories.Contexts
{
    public class ShuflRepositoryContext : DbContext
    {
        public ShuflRepositoryContext(DbContextOptions<ShuflRepositoryContext> options) : base(options) { }

        public DbSet<PasswordReset> PasswordResets { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
