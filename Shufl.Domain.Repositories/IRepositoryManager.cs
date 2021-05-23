using Shufl.Domain.Repositories.Group.Interfaces;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using Shufl.Domain.Repositories.User.Interfaces;
using System;

namespace Shufl.Domain.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        IAlbumRepository AlbumRepository { get; }

        IAlbumArtistRepository AlbumArtistRepository { get; }

        IAlbumImageRepository AlbumImageRepository { get; }

        IArtistRepository ArtistRepository { get; }

        IArtistImageRepository ArtistImageRepository { get; }

        IArtistGenreRepository ArtistGenreRepository { get; }

        IGenreRepository GenreRepository { get; }

        IGroupRepository GroupRepository { get; }

        IGroupAlbumRepository GroupAlbumRepository { get; }

        IGroupAlbumRatingRepository GroupAlbumRatingRepository { get; }

        IGroupInviteRepository GroupInviteRepository { get; }

        IGroupMemberRepository GroupMemberRepository { get; }

        IGroupPlaylistRepository GroupPlaylistRepository { get; }

        IGroupPlaylistRatingRepository GroupPlaylistRatingRepository { get; }

        IPasswordResetRepository PasswordResetRepository { get; }

        IPlaylistRepository PlaylistRepository { get; }

        IPlaylistImageRepository PlaylistImageRepository { get; }

        ITrackRepository TrackRepository { get; }

        ITrackArtistRepository TrackArtistRepository { get; }

        IUserRepository UserRepository { get; }

        IUserImageRepository UserImageRepository { get; }

        IUserVerificationRepository UserVerificationRepository { get; }
    }
}
