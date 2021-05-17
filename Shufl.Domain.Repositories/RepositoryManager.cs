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
        public IAlbumRepository AlbumRepository { get; private set; }
        public IAlbumArtistRepository AlbumArtistRepository { get; private set; }
        public IAlbumImageRepository AlbumImageRepository { get; private set; }
        public IArtistRepository ArtistRepository { get; private set; }
        public IArtistImageRepository ArtistImageRepository { get; private set; }
        public IArtistGenreRepository ArtistGenreRepository { get; private set; }
        public IGenreRepository GenreRepository { get; private set; }
        public IGroupRepository GroupRepository { get; private set; }
        public IGroupInviteRepository GroupInviteRepository { get; private set; }
        public IGroupMemberRepository GroupMemberRepository { get; private set; }
        public IGroupPlaylistRepository GroupPlaylistRepository { get; private set; }
        public IGroupPlaylistRatingRepository GroupPlaylistRatingRepository { get; private set; }
        public IGroupSuggestionRepository GroupSuggestionRepository { get; private set; }
        public IGroupSuggestionRatingRepository GroupSuggestionRatingRepository { get; private set; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public IPlaylistRepository PlaylistRepository { get; private set; }
        public IPlaylistImageRepository PlaylistImageRepository { get; private set; }
        public ITrackRepository TrackRepository { get; private set; }
        public ITrackArtistRepository TrackArtistRepository { get; private set; }
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
            GroupPlaylistRepository = new GroupPlaylistRepository(context);
            GroupPlaylistRatingRepository = new GroupPlaylistRatingRepository(context);
            GroupSuggestionRepository = new GroupSuggestionRepository(context);
            GroupSuggestionRatingRepository = new GroupSuggestionRatingRepository(context);
            PasswordResetRepository = new PasswordResetRepository(context);
            PlaylistRepository = new PlaylistRepository(context);
            PlaylistImageRepository = new PlaylistImageRepository(context);
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
