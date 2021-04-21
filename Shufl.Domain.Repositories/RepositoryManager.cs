using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group;
using Shufl.Domain.Repositories.Group.Interfaces;
using Shufl.Domain.Repositories.Interfaces;
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
        public IAlbumArtistRepository AlbumArtistRepository { get; }
        public IAlbumImageRepository AlbumImageRepository { get; }
        public IArtistRepository ArtistRepository { get; }
        public IArtistImageRepository ArtistImageRepository { get; }
        public IArtistGenreRepository ArtistGenreRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IGroupInviteRepository GroupInviteRepository { get; }
        public IGroupMemberRepository GroupMemberRepository { get; }
        public IGroupSuggestionRepository GroupSuggestionRepository { get; }
        public IGroupSuggestionRatingRepository GroupSuggestionRatingRepository { get; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public ITrackRepository TrackRepository { get; }
        public ITrackArtistRepository TrackArtistRepository { get; }
        public IUserRepository UserRepository { get; private set; }
        public IUserImageRepository UserImageRepository { get; private set; }
        public IUserVerificationRepository UserVerificationRepository { get; private set; }

        public RepositoryManager(ShuflContext context)
        {
            AlbumRepository = new AlbumRepository(context);
            AlbumArtistRepository = new AlbumArtistRepository(context);
            AlbumImageRepository = new AlbumImageRepository(context);
            ArtistRepository = new ArtistRepository(context);
            ArtistImageRepository = new ArtistImageRepository(context);
            ArtistGenreRepository = new ArtistGenreRepository(context);
            GenreRepository = new GenreRepository(context);
            GroupRepository = new GroupRepository(context);
            GroupInviteRepository = new GroupInviteRepository(context);
            GroupMemberRepository = new GroupMemberRepository(context);
            GroupSuggestionRepository = new GroupSuggestionRepository(context);
            GroupSuggestionRatingRepository = new GroupSuggestionRatingRepository(context);
            PasswordResetRepository = new PasswordResetRepository(context);
            TrackRepository = new TrackRepository(context);
            TrackArtistRepository = new TrackArtistRepository(context);
            UserRepository = new UserRepository(context);
            UserImageRepository = new UserImageRepository(context);
            UserVerificationRepository = new UserVerificationRepository(context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
