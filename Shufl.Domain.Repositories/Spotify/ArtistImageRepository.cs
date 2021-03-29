using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class ArtistImageRepository : RepositoryBase<ArtistImage>, IArtistImageRepository
    {
        public ArtistImageRepository(ShuflContext context) : base(context) { }
    }
}
