using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Songs
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<SongRatingAverage> GetSongAverageRating(int id)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
        COALESCE(T1.RatingsCount, 0) as RatingsCount,
        COALESCE(T2.Favorite, 0) as FavoriteCount,
        COALESCE(T3.Reviews, 0) as ReviewsCount, 
        T5.Name as ArtistName
        FROM Song T0
        LEFT JOIN(SELECT SongId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM SongRating GROUP BY SongId) T1 ON T1.SongId = T0.Id
        LEFT JOIN (SELECT SongId, COUNT(SongId) as Favorite FROM UserFavoriteSong GROUP BY SongId) T2 ON T0.Id = T2.SongId
        LEFT JOIN (SELECT SongId, COUNT(SongId) as Reviews FROM SongReview GROUP BY SongId) T3 ON T0.Id = T3.SongId
        LEFT JOIN Album T4 ON T0.AlbumId = T4.Id
        LEFT JOIN Artist T5 ON T4.ArtistId = T5.Id  
        WHERE T4.IsConfirmed = 1
        ";
            var query = _dbContext.SongRatingAverage.FromSqlRaw(sql);
            var entity = await query.FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<Song> GetSongFullDataByIdAsync(int id)
        {
            var entity = await _dbContext.Song
                .Include(album => album.Album)
                .Include(composer => composer.Composer)
                .Include(songReviews => songReviews.SongReviews)
                .ThenInclude(user => user.User)
                .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<List<TopSongsWithRating>> GetTopSongsWithRatingsAsync(int artistId)
        {
            var sql = @$"
SELECT TOP 3 T0.*, CAST(COALESCE(T3.AvgRating, 0) as numeric) as Rating, T1.Name as AlbumName, T2.Name as ArtistName
FROM Song T0
INNER JOIN Album T1 ON T1.Id = T0.AlbumId
INNER JOIN Artist T2 ON T2.Id = T1.ArtistId
LEFT JOIN
(
	SELECT SongId, AVG(Rating) as AvgRating
	FROM SongRating
	GROUP BY SongId
) T3 ON T3.SongId = T0.Id
WHERE T2.Id = '{artistId}' AND T1.IsConfirmed = 1
ORDER BY COALESCE(T3.AvgRating, 0) DESC, T0.Name";

            var query = _dbContext.TopSongsWithRating.FromSqlRaw(sql);

            var entities = await query.ToListAsync();
            return entities;
        }
        public async Task<List<SongRatingAverage>> GetSongsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
            var sql = @$"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
        COALESCE(T1.RatingsCount, 0) as RatingsCount,
        COALESCE(T2.Favorite, 0) as FavoriteCount,
        COALESCE(T3.Reviews, 0) as ReviewsCount, 
        T5.Name as ArtistName
        FROM Song T0
        LEFT JOIN(SELECT SongId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM SongRating GROUP BY SongId) T1 ON T1.SongId = T0.Id
        LEFT JOIN (SELECT SongId, COUNT(SongId) as Favorite FROM UserFavoriteSong GROUP BY SongId) T2 ON T0.Id = T2.SongId
        LEFT JOIN (SELECT SongId, COUNT(SongId) as Reviews FROM SongReview GROUP BY SongId) T3 ON T0.Id = T3.SongId
        LEFT JOIN Album T4 ON T0.AlbumId = T4.Id
        LEFT JOIN Artist T5 ON T4.ArtistId = T5.Id  
        WHERE T4.IsConfirmed = 1
        ";

            var query = _dbContext.SongRatingAverage.FromSqlRaw(sql);

            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(prp => prp.Name.Contains(searchString));

            query = query.Where(prp => prp.ReleaseDate >= startDate && prp.ReleaseDate <= endDate);
            switch (sortType)
            {
                case SortType.AlphabeticAsc:
                    query = query.OrderBy(prp => prp.Name);
                    break;
                case SortType.AlphabeticDesc:
                    query = query.OrderByDescending(prp => prp.Name);
                    break;
                case SortType.PopularityAsc:
                    query = query.OrderBy(prp => prp.Rating);
                    break;
                case SortType.PopularityDesc:
                    query = query.OrderByDescending(prp => prp.Rating);
                    break;
                default:
                    query = query.OrderBy(prp => prp.Name);
                    break;
            }

            query = query.Skip(pageNum * pageSize);
            query = query.Take(pageSize);

            var entities = await query.ToListAsync();
            return entities;
        }

        public async Task<List<SongRatingAverage>> GetSongRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 10)
        {
            var sql = @$"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
        COALESCE(T1.RatingsCount, 0) as RatingsCount,
        COALESCE(T2.Favorite, 0) as FavoriteCount,
        COALESCE(T3.Reviews, 0) as ReviewsCount, 
        T5.Name as ArtistName
        FROM Song T0
        LEFT JOIN(SELECT SongId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM SongRating GROUP BY SongId) T1 ON T1.SongId = T0.Id
        LEFT JOIN (SELECT SongId, COUNT(SongId) as Favorite FROM UserFavoriteSong GROUP BY SongId) T2 ON T0.Id = T2.SongId
        LEFT JOIN (SELECT SongId, COUNT(SongId) as Reviews FROM SongReview GROUP BY SongId) T3 ON T0.Id = T3.SongId
        LEFT JOIN Album T4 ON T0.AlbumId = T4.Id
        LEFT JOIN Artist T5 ON T4.ArtistId = T5.Id  
        WHERE T4.IsConfirmed = 1
        ";

            var query = _dbContext.SongRatingAverage.FromSqlRaw(sql);

            switch (sortType)
            {
                case RankSortType.RatingAsc:
                    query = query.OrderBy(prp => prp.Rating);
                    break;
                case RankSortType.RatingDesc:
                    query = query.OrderByDescending(prp => prp.Rating);
                    break;
                case RankSortType.PopularityAsc:
                    query = query.OrderBy(prp => prp.RatingsCount);
                    break;
                case RankSortType.PopularityDesc:
                    query = query.OrderByDescending(prp => prp.RatingsCount);
                    break;
                case RankSortType.FavoriteAsc:
                    query = query.OrderBy(prp => prp.FavoriteCount);
                    break;
                case RankSortType.FavoriteDesc:
                    query = query.OrderByDescending(prp => prp.FavoriteCount);
                    break;
                case RankSortType.ReviewsAsc:
                    query = query.OrderBy(prp => prp.ReviewsCount);
                    break;
                case RankSortType.ReviewsDesc:
                    query = query.OrderByDescending(prp => prp.ReviewsCount);
                    break;
                default:
                    query = query.OrderByDescending(prp => prp.Rating);
                    break;
            }

            query = query.Skip(pageNum * pageSize);
            query = query.Take(pageSize);

            var entities = await query.ToListAsync();
            return entities;
        }

    }

}
