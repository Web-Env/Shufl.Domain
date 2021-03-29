using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify
{
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(ShuflContext context) : base(context) { }

        public async Task<Track> CheckExistsBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Tracks.Where(t => t.SpotifyId == spotifyId).FirstOrDefaultAsync();
        }

        public async Task<Track> GetBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Tracks.Where(t => t.SpotifyId == spotifyId)
                .Include(t => t.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(t => t.TrackArtists)
                    .ThenInclude(aa => aa.Artist)
                        .ThenInclude(a => a.ArtistImages)
                .Include(t => t.Album)
                    .ThenInclude(a => a.AlbumImages)
                .FirstOrDefaultAsync();
        }
    }
}
