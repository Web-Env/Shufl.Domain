using Microsoft.EntityFrameworkCore;

namespace Shufl.Domain.Entities
{
    public class ShuflDbContext : ShuflContext
    {
        public ShuflDbContext()
        {
        }

        public ShuflDbContext(DbContextOptions<ShuflContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
