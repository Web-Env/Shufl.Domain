using Microsoft.EntityFrameworkCore;

namespace Shufl.Domain.Entities
{
    public class ShuflDbContext : ShuflContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
