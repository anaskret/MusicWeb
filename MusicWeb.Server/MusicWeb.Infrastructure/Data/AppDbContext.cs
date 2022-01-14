﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Models.Entities.Ratings;
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

        public DbSet<Album> Album { get; set; }
        public DbSet<AlbumReview> AlbumReview { get; set; }
        public DbSet<ArtistsOnTheAlbum> ArtistsOnTheAlbum { get; set; }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<ArtistComment> ArtistComment { get; set; }
        public DbSet<BandMember> BandMember { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Song> Song { get; set; }
        public DbSet<SongGuestArtist> SongGuestArtist { get; set; }
        public DbSet<SongReview> SongReview { get; set; }

        public DbSet<UserFavoriteAlbum> UserFavoriteAlbum { get; set; }
        public DbSet<UserFavoriteArtist> UserFavoriteArtist { get; set; }
        public DbSet<UserFavoriteSong> UserFavoriteSong { get; set; }
        public DbSet<UserFriend> UserFriend { get; set; }
        public DbSet<UserObservedArtist> UserObservedArtist { get; set; }

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }

        public DbSet<Post> Post{ get; set; }
        public DbSet<PostLike> PostLike{ get; set; }
        public DbSet<PostComment> PostComment{ get; set; }
        public DbSet<AlbumRating> AlbumRating { get; set; }
        public DbSet<ArtistRating> ArtistRating { get; set; }

        //Keyless
        public DbSet<ArtistRatingAverage> ArtistRatingAverage { get; set; }
        public DbSet<AlbumRatingAverage> AlbumRatingAverage { get; set; }
        public DbSet<AlbumReviewRating> AlbumReviewRating { get; set; }
        public DbSet<SongRatingAverage> SongRatingAverage{ get; set; }
        public DbSet<SongReviewRating> SongReviewRating { get; set; }
        public DbSet<UserAndArtistPost> UserAndArtistPost { get; set; }
        public DbSet<TopSongsWithRating> TopSongsWithRating { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(e => e.Artist)
                .WithOne(a => a.ArtistUser)
                .HasForeignKey<ApplicationUser>(e => e.ArtistId);
            });

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
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.AlbumGenre)
                    .WithMany(a => a.Albums)
                    .HasForeignKey(e => e.AlbumGenreId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<AlbumReview>(entity =>
            {
                entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasDefaultValue("Review");

                entity.Property(e => e.PostDate)
                    .IsRequired();

                entity.HasOne(e => e.Album)
                    .WithMany(a => a.AlbumReviews)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.AlbumReviews)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.AlbumRating)
                    .WithOne(a => a.AlbumReview)
                    .HasForeignKey<AlbumReview>(e => e.RatingId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(false);
                   // .HasForeignKey<AlbumReview>(e => e.RatingId);
            });

            modelBuilder.Entity<ArtistsOnTheAlbum>(entity =>
            {
                entity.HasOne(e => e.Album)
                    .WithMany(a => a.ArtistsOnTheAlbums)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.ArtistsOnTheAlbums)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.SetNull)
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();


                entity.HasOne(e => e.ArtistUser)
                .WithOne(a => a.Artist)
                .HasForeignKey<Artist>(e => e.UserId);
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(a => a.ArtistComments)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(a => a.Chats)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.Friend)
                    .WithMany(a => a.FriendChats)
                    .HasForeignKey(e => e.FriendId)
                    .OnDelete(DeleteBehavior.SetNull)
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.Chat)
                    .WithMany(a => a.Messages)
                    .HasForeignKey(e => e.ChatId)
                    .OnDelete(DeleteBehavior.SetNull)
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
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(b => b.Member)
                .WithOne(a => a.BandMember)
                .HasForeignKey<BandMember>(b => b.ArtistId)
                .OnDelete(DeleteBehavior.SetNull);
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
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.Composer)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(e => e.ComposerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<SongGuestArtist>(entity =>
            {
                entity.HasOne(e => e.Song)
                    .WithMany(a => a.SongGuestArtists)
                    .HasForeignKey(e => e.SongId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.SongGuestArtists)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<SongReview>(entity =>
            {
                entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasDefaultValue("Review");

                entity.Property(e => e.PostDate)
                    .IsRequired();

                entity.HasOne(e => e.Song)
                    .WithMany(a => a.SongReviews)
                    .HasForeignKey(e => e.SongId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.SongReviews)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFavoriteAlbum>(entity =>
            {
                entity.Property(e => e.FavoriteDate)
                    .IsRequired();

                entity.HasOne(e => e.Album)
                    .WithMany(a => a.UserFavoriteAlbums)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserFavoriteAlbums)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFavoriteArtist>(entity =>
            {
                entity.Property(e => e.FavoriteDate)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.UserFavoriteArtists)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserFavoriteArtists)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<UserObservedArtist>(entity =>
            {
                entity.Property(e => e.ObservedDate)
                    .IsRequired();

                entity.HasOne(e => e.Artist)
                    .WithMany(a => a.UserObservedArtists)
                    .HasForeignKey(e => e.ArtistId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserObservedArtists)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFavoriteSong>(entity =>
            {
                entity.Property(e => e.FavoriteDate)
                    .IsRequired();

                entity.HasOne(e => e.Song)
                    .WithMany(a => a.UserFavoriteSongs)
                    .HasForeignKey(e => e.SongId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserFavoriteSongs)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<UserFriend>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(a => a.UserFriends)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();

                entity.HasOne(e => e.Friend)
                    .WithMany(u => u.FriendUsers)
                    .HasForeignKey(e => e.FriendId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(e => e.Poster)
                .WithMany(p => p.Posts)
                .HasForeignKey(e => e.PosterId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.PosterArtist)
                .WithMany(p => p.Posts)
                .HasForeignKey(e => e.ArtistPosterId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Album)
                .WithMany(p => p.Posts)
                .HasForeignKey(e => e.AlbumId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PostLike>(entity =>
            {
                entity.HasOne(e => e.Post)
                .WithMany(p => p.PostLikes)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.User)
                .WithMany(p => p.PostLikes)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.HasOne(e => e.Post)
                .WithMany(p => p.PostComments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.User)
                .WithMany(p => p.PostComments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ArtistRating>(entity =>
            {
                entity.Property(e => e.Rating)
                .IsRequired(true);

                entity.HasOne(e => e.Artist)
                .WithMany(p => p.ArtistRatings)
                .HasForeignKey(e => e.ArtistId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(true);

                entity.HasOne(e => e.User)
                .WithMany(p => p.ArtistRatings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(true);
            });

            modelBuilder.Entity<AlbumRating>(entity =>
            {
                entity.Property(e => e.Rating)
                .IsRequired(true);

                entity.HasOne(e => e.Album)
                .WithMany(p => p.AlbumRatings)
                .HasForeignKey(e => e.AlbumId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(true);

                entity.HasOne(e => e.User)
                .WithMany(p => p.AlbumRatings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(true);

                entity.HasOne(e => e.AlbumReview)
                .WithOne(a => a.AlbumRating)
                .HasForeignKey<AlbumRating>(e => e.ReviewId);
            });

            modelBuilder.Entity<SongRating>(entity =>
            {
                entity.Property(e => e.Rating)
                .IsRequired(true);
            });

            modelBuilder.Entity<ArtistRatingAverage>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<AlbumRatingAverage>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<AlbumReviewRating>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SongReviewRating>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SongRatingAverage>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<UserAndArtistPost>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TopSongsWithRating>(entity =>
            {
                entity.HasNoKey();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
