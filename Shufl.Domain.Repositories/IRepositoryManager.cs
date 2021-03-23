using Shufl.Domain.Repositories.Music.Interfaces;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using Shufl.Domain.Repositories.User.Interfaces;
using System;

namespace Shufl.Domain.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        IAlbumRepository AlbumRepository { get; }

        IArtistRepository ArtistRepository { get; }

        IArtistGenreRepository ArtistGenreRepository { get; }

        IGenreRepository GenreRepository { get; }

        IPasswordResetRepository PasswordResetRepository { get; }

        ITrackRepository TrackRepository { get; }

        IUserRepository UserRepository { get; }

        IUserVerificationRepository UserVerificationRepository { get; }
    }
}
