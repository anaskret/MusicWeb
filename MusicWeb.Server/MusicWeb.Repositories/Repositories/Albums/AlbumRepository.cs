using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Albums
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AlbumRatingAverage> GetAlbumAverageRating(int id)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount, 
            COALESCE(T3.Reviews, 0) as ReviewsCount
            FROM Album T0
            LEFT JOIN(SELECT AlbumId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM AlbumRating GROUP BY AlbumId) T1 ON T1.AlbumId = T0.Id
            LEFT JOIN (SELECT AlbumId, COUNT(AlbumId) as Favorite FROM UserFavoriteAlbum GROUP BY AlbumId) T2 ON T0.Id = T2.AlbumId
            LEFT JOIN (SELECT AlbumId, COUNT(AlbumId) as Reviews FROM AlbumReview GROUP BY AlbumId) T3 ON T0.Id = T3.AlbumId";
            var query = _dbContext.AlbumRatingAverage.FromSqlRaw(sql);
            var entity = await query.FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<Album> GetFullAlbumDataByIdAsync(int id)
        {
            var entity = await _dbContext.Album
                .Include(songs => songs.Songs)
                .Include(reviews => reviews.AlbumReviews)
                .ThenInclude(user => user.User)
                .Include(artist => artist.Artist)
                .Include(genre => genre.AlbumGenre)
                .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<List<AlbumRatingAverage>> GetAlbumsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
            var sql = @$"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount, 
            COALESCE(T3.Reviews, 0) as ReviewsCount
            FROM Album T0
            LEFT JOIN(SELECT AlbumId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM AlbumRating GROUP BY AlbumId) T1 ON T1.AlbumId = T0.Id
            LEFT JOIN (SELECT AlbumId, COUNT(AlbumId) as Favorite FROM UserFavoriteAlbum GROUP BY AlbumId) T2 ON T0.Id = T2.AlbumId
            LEFT JOIN (SELECT AlbumId, COUNT(AlbumId) as Reviews FROM AlbumReview GROUP BY AlbumId) T3 ON T0.Id = T3.AlbumId";

            var query = _dbContext.AlbumRatingAverage.FromSqlRaw(sql);

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

        public async Task<List<AlbumRatingAverage>> GetAlbumRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 10)
        {
            var sql = @$"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount, 
            COALESCE(T3.Reviews, 0) as ReviewsCount
            FROM Album T0
            LEFT JOIN(SELECT AlbumId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM AlbumRating GROUP BY AlbumId) T1 ON T1.AlbumId = T0.Id
            LEFT JOIN (SELECT AlbumId, COUNT(AlbumId) as Favorite FROM UserFavoriteAlbum GROUP BY AlbumId) T2 ON T0.Id = T2.AlbumId
            LEFT JOIN (SELECT AlbumId, COUNT(AlbumId) as Reviews FROM AlbumReview GROUP BY AlbumId) T3 ON T0.Id = T3.AlbumId";

            var query = _dbContext.AlbumRatingAverage.FromSqlRaw(sql);

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
