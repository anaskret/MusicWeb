using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumReview> AlbumReviews{ get; set; }
        public DbSet<ArtistsOnTheAlbum> ArtistsOnTheAlbums{ get; set; }

        public DbSet<Artist> Artists{ get; set; }
        public DbSet<ArtistComment> ArtistComments{ get; set; }
        public DbSet<ArtistGenre> ArtistGenres{ get; set; }
        public DbSet<BandMember> BandMembers{ get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Country> Countries{ get; set; }
        public DbSet<State> States{ get; set; }
        public DbSet<City> Cities{ get; set; }

        public DbSet<Song> Songs{ get; set; }
        public DbSet<SongGuestArtist> SongGuestArtist{ get; set; }
        public DbSet<SongReview> SongReviews{ get; set; }

        public DbSet<UserFavoriteAlbum> UserFavoriteAlbums{ get; set; }
        public DbSet<UserFavoriteArtist> UserFavoriteArtists{ get; set; }
        public DbSet<UserFavoriteSong> UserFavoriteSongs{ get; set; }
        public DbSet<UserFriend> UserFriends{ get; set; }
        public DbSet<UserObservedArtist> UserObservedArtists{ get; set; }

        public DbSet<Chat> Chats{ get; set; }
        public DbSet<Message> Messages{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReleaseDate)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.Albums)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<AlbumReview>(entity =>
            {
                entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasDefaultValue(1);

                entity.Property(e => e.PostDate)
                    .IsRequired();

                entity.HasOne(e => e.Album)
                    .WithMany(a => a.AlbumReviews)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.AlbumReviews)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<ArtistsOnTheAlbum>(entity =>
            {
                entity.HasOne(e => e.Album)
                    .WithMany(a => a.ArtistsOnTheAlbums)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.ArtistsOnTheAlbums)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.EstablishmentDate)
                    .IsRequired();

                entity.HasOne(e => e.BandMember)
                    .WithOne(a => a.Member)
                    .HasForeignKey<Artist>(e => e.BandId);

                entity.HasOne(e => e.Country)
                    .WithMany(a => a.Artists)
                    .HasForeignKey(e => e.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.State)
                    .WithMany(a => a.Artists)
                    .HasForeignKey(e => e.StateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.City)
                    .WithMany(a => a.Artists)
                    .HasForeignKey(e => e.CityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<ArtistComment>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.Property(e => e.PostDate)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.ArtistComments)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(a => a.ArtistComments)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<ArtistGenre>(entity =>
            {
                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.ArtistGenres)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Genre)
                    .WithMany(a => a.ArtistGenres)
                    .HasForeignKey(e => e.GenreId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(a => a.Chats)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Friend)
                    .WithMany(a => a.FriendChats)
                    .HasForeignKey(e => e.FriendId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Text)
                    .HasMaxLength(1000)
                    .IsRequired();

                entity.Property(e => e.SendDate)
                    .IsRequired();

                entity.HasOne(e => e.Sender)
                    .WithMany(a => a.Messages)
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Chat)
                    .WithMany(a => a.Messages)
                    .HasForeignKey(e => e.ChatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<BandMember>(entity =>
            {
                entity.HasOne(b => b.Band)
                .WithMany(a => a.Band)
                .HasForeignKey(b => b.BandId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Member)
                .WithOne(a => a.BandMember)
                .HasForeignKey<BandMember>(b => b.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.ReleaseDate)
                    .IsRequired();

                entity.HasOne(e => e.Album)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Composer)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(e => e.ComposerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<SongGuestArtist>(entity =>
            {
                entity.HasOne(e => e.Song)
                    .WithMany(a => a.SongGuestArtists)
                    .HasForeignKey(e => e.SongId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.SongGuestArtists)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<SongReview>(entity =>
            {
                entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasDefaultValue(1);

                entity.Property(e => e.PostDate)
                    .IsRequired();

                entity.HasOne(e => e.Song)
                    .WithMany(a => a.SongReviews)
                    .HasForeignKey(e => e.SongId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.SongReviews)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFavoriteAlbum>(entity =>
            {
                entity.Property(e => e.FavoriteDate)
                    .IsRequired();

                entity.HasOne(e => e.Album)
                    .WithMany(a => a.UserFavoriteAlbums)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserFavoriteAlbums)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFavoriteArtist>(entity =>
            {
                entity.Property(e => e.FavoriteDate)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.UserFavoriteArtists)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserFavoriteArtists)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<UserObservedArtist>(entity =>
            {
                entity.Property(e => e.ObservedDate)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.UserObservedArtists)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserObservedArtists)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFavoriteSong>(entity =>
            {
                entity.Property(e => e.FavoriteDate)
                    .IsRequired();

                entity.HasOne(e => e.Song)
                    .WithMany(a => a.UserFavoriteSongs)
                    .HasForeignKey(e => e.SongId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserFavoriteSongs)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFriend>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(a => a.UserFriends)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(e => e.Friend)
                    .WithMany(u => u.FriendUsers)
                    .HasForeignKey(e => e.FriendId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
