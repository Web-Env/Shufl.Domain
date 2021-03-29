using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(ShuflContext context) : base(context) { }

        public async Task<Album> CheckExistsBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Albums.Where(a => a.SpotifyId == spotifyId).FirstOrDefaultAsync();
        }

        public async Task<Album> GetBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Albums.Where(a => a.SpotifyId == spotifyId)
                .Include(a => a.AlbumArtists)
                    .ThenInclude(aa => aa.Artist)
                        .ThenInclude(a => a.ArtistImages)
                .Include(a => a.AlbumArtists)
                    .ThenInclude(aa => aa.Artist)
                        .ThenInclude(a => a.ArtistGenres)
                            .ThenInclude(ag => ag.Genre)
                .Include(a => a.Tracks)
                    .ThenInclude(t => t.TrackArtists)
                .Include(a => a.AlbumImages)
                .FirstOrDefaultAsync();
        }
    }
}
