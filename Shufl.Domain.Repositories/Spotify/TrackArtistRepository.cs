using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;

namespace Shufl.Domain.Repositories.Spotify
{
    public class TrackArtistRepository : RepositoryBase<TrackArtist>, ITrackArtistRepository
    {
        public TrackArtistRepository(ShuflContext context) : base(context) { }
    }
}
