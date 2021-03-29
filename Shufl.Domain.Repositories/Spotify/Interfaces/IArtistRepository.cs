using Shufl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify.Interfaces
{
    public interface IArtistRepository : ISpotifyRepositoryBase<Artist>
    {
        Task<Artist> GetManyBySpotifyIdsAsync(IEnumerable<string> spotifyId);
    }
}
