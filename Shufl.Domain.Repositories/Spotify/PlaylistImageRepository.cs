using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class PlaylistImageRepository : RepositoryBase<PlaylistImage>, IPlaylistImageRepository
    {
        public PlaylistImageRepository(ShuflContext context) : base(context) { }
    }
}
