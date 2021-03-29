using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify.Interfaces
{
    public interface ISpotifyRepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        Task<T> CheckExistsBySpotifyIdAsync(string spotifyId);

        Task<T> GetBySpotifyIdAsync(string spotifyId);
    }
}
