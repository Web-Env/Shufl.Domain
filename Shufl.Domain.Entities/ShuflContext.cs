using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class ShuflContext : DbContext
    {
        public ShuflContext()
        {
        }

        public ShuflContext(DbContextOptions<ShuflContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumArtist> AlbumArtists { get; set; }
        public virtual DbSet<AlbumImage> AlbumImages { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistGenre> ArtistGenres { get; set; }
        public virtual DbSet<ArtistImage> ArtistImages { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupAlbum> GroupAlbums { get; set; }
        public virtual DbSet<GroupAlbumRating> GroupAlbumRatings { get; set; }
        public virtual DbSet<GroupInvite> GroupInvites { get; set; }
        public virtual DbSet<GroupMember> GroupMembers { get; set; }
        public virtual DbSet<GroupPlaylist> GroupPlaylists { get; set; }
        public virtual DbSet<GroupPlaylistRating> GroupPlaylistRatings { get; set; }
        public virtual DbSet<PasswordReset> PasswordResets { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistImage> PlaylistImages { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackArtist> TrackArtists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<UserVerification> UserVerifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Shufl;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.HasIndex(e => e.Name, "IX_Album_Name");

                entity.HasIndex(e => e.SpotifyId, "IX_Album_SpotifyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.SpotifyId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<AlbumArtist>(entity =>
            {
                entity.ToTable("AlbumArtist");

                entity.HasIndex(e => e.AlbumId, "IX_AlbumArtist_AlbumId");

                entity.HasIndex(e => new { e.AlbumId, e.ArtistId }, "IX_AlbumArtist_AlbumId_ArtistId")
                    .IsUnique();

                entity.HasIndex(e => e.ArtistId, "IX_AlbumArtist_ArtistId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtist_Album");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtist_Artist");
            });

            modelBuilder.Entity<AlbumImage>(entity =>
            {
                entity.ToTable("AlbumImage");

                entity.HasIndex(e => e.AlbumId, "IX_AlbumImage_AlbumId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Uri)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumImages)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumImage_Album");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.HasIndex(e => e.Name, "IX_Artist_Name");

                entity.HasIndex(e => e.SpotifyId, "IX_Artist_SpotifyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SpotifyId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ArtistGenre>(entity =>
            {
                entity.ToTable("ArtistGenre");

                entity.HasIndex(e => new { e.ArtistId, e.GenreId }, "IX_ArtistGenre_ArtistId_GenreId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistGenres)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGenre_Artist");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.ArtistGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGenre_Genre");
            });

            modelBuilder.Entity<ArtistImage>(entity =>
            {
                entity.ToTable("ArtistImage");

                entity.HasIndex(e => e.ArtistId, "IX_ArtistImage_ArtistId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Uri)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistImages)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistImage_Artist");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.HasIndex(e => e.Code, "IX_Genre_Code")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.HasIndex(e => e.Identifier, "IX_Group_Identifier")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Group_Name");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsPrivate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LastUpatedByNavigation)
                    .WithMany(p => p.GroupLastUpatedByNavigations)
                    .HasForeignKey(d => d.LastUpatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_User_LastUpdatedBy");
            });

            modelBuilder.Entity<GroupAlbum>(entity =>
            {
                entity.ToTable("GroupAlbum");

                entity.HasIndex(e => new { e.GroupId, e.AlbumId }, "IX_GroupAlbum_GroupId_AlbumId");

                entity.HasIndex(e => new { e.GroupId, e.Identifier }, "IX_GroupAlbum_GroupId_Identifier")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsRandom)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.GroupAlbums)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupAlbum_Album");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupAlbumCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupAlbums)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupAlbum_Group");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.GroupAlbumLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupAlbumRating>(entity =>
            {
                entity.ToTable("GroupAlbumRating");

                entity.HasIndex(e => e.GroupAlbumId, "IX_GroupAlbumRating");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Comment).HasMaxLength(1500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InstrumentalsRating).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.LyricsRating).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.OverallRating).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.StructureRating).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.VocalsRating).HasColumnType("decimal(3, 1)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupAlbumRatingCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.GroupAlbum)
                    .WithMany(p => p.GroupAlbumRatings)
                    .HasForeignKey(d => d.GroupAlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupAlbumRating_GroupAlbum");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.GroupAlbumRatingLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupInvite>(entity =>
            {
                entity.ToTable("GroupInvite");

                entity.HasIndex(e => new { e.GroupId, e.Identifier }, "IX_GroupInvite_GroupId_Identifier")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupInviteCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupInvites)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupInvite_Group");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.GroupInviteLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.ToTable("GroupMember");

                entity.HasIndex(e => new { e.GroupId, e.UserId }, "IX_GroupMember_GroupId_UserId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupMemberCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMember_Group");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.GroupMemberLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMemberUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupPlaylist>(entity =>
            {
                entity.ToTable("GroupPlaylist");

                entity.HasIndex(e => new { e.GroupId, e.Identifier }, "IX_GroupPlaylist_GroupId_Identifier")
                    .IsUnique();

                entity.HasIndex(e => new { e.GroupId, e.PlaylistId }, "IX_GroupPlaylist_GroupId_PlaylistId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupPlaylistCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupPlaylists)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupPlaylist_Group");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.GroupPlaylistLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.GroupPlaylists)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupPlaylist_Playlist");
            });

            modelBuilder.Entity<GroupPlaylistRating>(entity =>
            {
                entity.ToTable("GroupPlaylistRating");

                entity.HasIndex(e => e.GroupPlaylistId, "IX_GroupPlaylistRating_GroupPlaylistId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Comment).HasMaxLength(1500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.OverallRating).HasColumnType("decimal(3, 1)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupPlaylistRatingCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.GroupPlaylist)
                    .WithMany(p => p.GroupPlaylistRatings)
                    .HasForeignKey(d => d.GroupPlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupPlaylistRating_GroupPlaylist");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.GroupPlaylistRatingLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.ToTable("PasswordReset");

                entity.HasIndex(e => e.Identifier, "IX_PasswordReset_Identifier")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequesterAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsedByAddress)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(344)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.HasIndex(e => e.SpotifyId, "IX_Playlist_SpotifyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SpotifyId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PlaylistCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.PlaylistLastUpdatedByNavigations)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PlaylistImage>(entity =>
            {
                entity.ToTable("PlaylistImage");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistImages)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistImage_Playlist");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.HasIndex(e => e.Name, "IX_Track_Name");

                entity.HasIndex(e => e.SpotifyId, "IX_Track_SpotifyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SpotifyId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_Album");
            });

            modelBuilder.Entity<TrackArtist>(entity =>
            {
                entity.ToTable("TrackArtist");

                entity.HasIndex(e => e.ArtistId, "IX_TrackArtist_ArtistId");

                entity.HasIndex(e => e.TrackId, "IX_TrackArtist_TrackId");

                entity.HasIndex(e => new { e.TrackId, e.ArtistId }, "IX_TrackArtist_TrackId_ArtistId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.TrackArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackArtist_Artist");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TrackArtists)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackArtist_Track");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => new { e.Email, e.Password }, "IX_User_Email_Password")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SpotifyMarket)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SpotifyRefreshToken)
                    .HasMaxLength(344)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SpotifyUsername)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserSecret)
                    .IsRequired()
                    .HasMaxLength(344)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserImage>(entity =>
            {
                entity.ToTable("UserImage");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserImages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserImage_User");
            });

            modelBuilder.Entity<UserVerification>(entity =>
            {
                entity.ToTable("UserVerification");

                entity.HasIndex(e => e.Identifier, "IX_UserVerification_Identifier")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequesterAddress)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsedByAddress)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsedOn).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserVerifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserVerification_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
