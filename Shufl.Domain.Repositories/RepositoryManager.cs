using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group;
using Shufl.Domain.Repositories.Group.Interfaces;
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
        public IGroupRepository GroupRepository { get; }
        public IGroupInviteRepository GroupInviteRepository { get; }
        public IGroupMemberRepository GroupMemberRepository { get; }
        public IGroupSuggestionRepository GroupSuggestionRepository { get; }
        public IGroupSuggestionRatingRepository GroupSuggestionRatingRepository { get; }
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public ITrackRepository TrackRepository { get; }
        public IUserRepository UserRepository { get; private set; }
        public IUserVerificationRepository UserVerificationRepository { get; private set; }

        public RepositoryManager(ShuflDbContext context)
        {
            AlbumRepository = new AlbumRepository(context);
            ArtistRepository = new ArtistRepository(context);
            ArtistGenreRepository = new ArtistGenreRepository(context);
            GenreRepository = new GenreRepository(context);
            GroupRepository = new GroupRepository(context);
            GroupInviteRepository = new GroupInviteRepository(context);
            GroupMemberRepository = new GroupMemberRepository(context);
            GroupSuggestionRepository = new GroupSuggestionRepository(context);
            GroupSuggestionRatingRepository = new GroupSuggestionRatingRepository(context);
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
