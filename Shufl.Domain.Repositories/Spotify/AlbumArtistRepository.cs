using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class AlbumArtistRepository : RepositoryBase<AlbumArtist>, IAlbumArtistRepository
    {
        public AlbumArtistRepository(ShuflContext context) : base(context) { }
    }
}
