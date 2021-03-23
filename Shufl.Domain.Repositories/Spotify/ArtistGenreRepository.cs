using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class ArtistGenreRepository : RepositoryBase<ArtistGenre>, IArtistGenreRepository
    {
        public ArtistGenreRepository(ShuflContext context) : base(context) { }
    }
}
