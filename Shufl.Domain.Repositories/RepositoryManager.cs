using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using Shufl.Domain.Repositories.Music;
using Shufl.Domain.Repositories.Music.Interfaces;
using Shufl.Domain.Repositories.Spotify;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using Shufl.Domain.Repositories.User;
using Shufl.Domain.Repositories.User.Interfaces;
using System;

namespace Shufl.Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public IAlbumRepository AlbumRepository { get; }
        public IArtistRepository ArtistRepository { get; }
        public IArtistGenreRepository ArtistGenreRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public ITrackRepository TrackRepository { get; }
        public IUserRepository UserRepository { get; private set; }
        public IUserVerificationRepository UserVerificationRepository { get; private set; }

        public RepositoryManager(ShuflContext context)
        {
            AlbumRepository = new AlbumRepository(context);
            ArtistRepository = new ArtistRepository(context);
            ArtistGenreRepository = new ArtistGenreRepository(context);
            GenreRepository = new GenreRepository(context);
            PasswordResetRepository = new PasswordResetRepository(context);
            TrackRepository = new TrackRepository(context);
            UserRepository = new UserRepository(context);
            UserVerificationRepository = new UserVerificationRepository(context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
