using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Music.Interfaces;

namespace Shufl.Domain.Repositories.Music
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ShuflDbContext context) : base(context) { }
    }
}
