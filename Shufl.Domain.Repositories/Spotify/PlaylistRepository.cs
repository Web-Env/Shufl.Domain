using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ShuflContext context) : base(context) { }

        public async Task<Playlist> CheckExistsBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Playlists.Where(p => p.SpotifyId == spotifyId).FirstOrDefaultAsync();
        }

        public async Task<Playlist> GetBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Playlists.Where(p => p.SpotifyId == spotifyId)
                .Include(p => p.PlaylistImages)
                .FirstOrDefaultAsync();
        }
    }
}
