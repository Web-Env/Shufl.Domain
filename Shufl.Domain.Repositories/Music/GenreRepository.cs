using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Music.Interfaces;

namespace Shufl.Domain.Repositories.Music
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ShuflContext context) : base(context) { }
    }
}
