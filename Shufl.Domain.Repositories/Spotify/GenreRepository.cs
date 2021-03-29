using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ShuflContext context) : base(context) { }
    }
}
