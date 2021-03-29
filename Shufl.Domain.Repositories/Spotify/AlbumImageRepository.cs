using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class AlbumImageRepository : RepositoryBase<AlbumImage>, IAlbumImageRepository
    {
        public AlbumImageRepository(ShuflContext context) : base(context) { }
    }
}
