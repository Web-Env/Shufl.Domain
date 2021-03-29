using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(ShuflContext context) : base(context) { }

        public async Task<Artist> CheckExistsBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Artists.Where(a => a.SpotifyId == spotifyId).FirstOrDefaultAsync();
        }

        public async Task<Artist> GetBySpotifyIdAsync(string spotifyId)
        {
            return await _ShuflContext.Artists.Where(a => a.SpotifyId == spotifyId)
                .Include(a => a.AlbumArtists)
                    .ThenInclude(aa => aa.Album)
                        .ThenInclude(a => a.Tracks)
                            .ThenInclude(t => t.TrackArtists)
                                .ThenInclude(ta => ta.Artist)
                .Include(a => a.AlbumArtists)
                    .ThenInclude(aa => aa.Album)
                        .ThenInclude(a => a.AlbumImages)
                .Include(a => a.ArtistGenres)
                    .ThenInclude(ag => ag.Genre)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Artist>> GetManyBySpotifyIdsAsync(IEnumerable<string> spotifyId)
        {
            return await _ShuflContext.Artists.Where(a => spotifyId.Contains(a.SpotifyId))
                .ToListAsync();
        }
    }
}
