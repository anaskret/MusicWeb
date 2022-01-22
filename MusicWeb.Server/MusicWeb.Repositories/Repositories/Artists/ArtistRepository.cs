using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Artists
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Artist> GetFullArtistDataByIdAsync(int id)
        {
            var entity = await _dbContext.Artist
                                             .Include(origin => origin.Country)
                                             .Include(albums => albums.Albums)
                                             .ThenInclude(genres => genres.AlbumGenre)
                                             .Include(band => band.Band)
                                             .ThenInclude(member => member.Member)
                                             .Include(comments => comments.ArtistComments).FirstOrDefaultAsync(prp => prp.Id == id);

            return entity;
        }

        public async Task<ArtistRatingAverage> GetArtistAverageRating(int id)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount,
            COALESCE(T3.Observed, 0) as ObservedCount
            FROM Artist T0
            LEFT JOIN(SELECT ArtistId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM ArtistRating GROUP BY ArtistId) T1 ON T1.ArtistId = T0.Id
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Favorite FROM UserFavoriteArtist GROUP BY ArtistId) T2 ON T0.Id = T2.ArtistId
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Observed FROM UserObservedArtist GROUP BY ArtistId) T3 ON T0.Id = T3.ArtistId";
            var query = _dbContext.ArtistRatingAverage.FromSqlRaw(sql);
            var entity = await query.FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<List<ArtistRatingAverage>> GetArtistsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
            var sql = @$"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount,
            COALESCE(T3.Observed, 0) as ObservedCount
            FROM Artist T0
            LEFT JOIN(SELECT ArtistId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM ArtistRating GROUP BY ArtistId) T1 ON T1.ArtistId = T0.Id
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Favorite FROM UserFavoriteArtist GROUP BY ArtistId) T2 ON T0.Id = T2.ArtistId
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Observed FROM UserObservedArtist GROUP BY ArtistId) T3 ON T0.Id = T3.ArtistId";

            var query = _dbContext.ArtistRatingAverage.FromSqlRaw(sql);

            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(prp => prp.Name.Contains(searchString));

            query = query.Where(prp => prp.EstablishmentDate >= startDate && prp.EstablishmentDate <= endDate );
            switch (sortType)
            {
                case SortType.AlphabeticAsc:
                    query = query.OrderBy(prp => prp.Name);
                break;
                case SortType.AlphabeticDesc:
                    query =  query.OrderByDescending(prp => prp.Name);
                break;
                case SortType.PopularityAsc:
                    query =  query.OrderBy(prp => prp.Rating);
                break;
                case SortType.PopularityDesc:
                    query =  query.OrderByDescending(prp => prp.Rating);
                break;
                default:
                    query =  query.OrderBy(prp => prp.Name);
                break;
            }

            query = query.Skip(pageNum * pageSize);
            query = query.Take(pageSize);

            var entities = await query.ToListAsync();
            return entities;
        }

        public async Task<List<ArtistRatingAverage>> GetArtistRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 10)
        {
            var sql = @$"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount, 
            COALESCE(T3.Observed, 0) as ObservedCount
            FROM Artist T0
            LEFT JOIN(SELECT ArtistId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM ArtistRating GROUP BY ArtistId) T1 ON T1.ArtistId = T0.Id
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Favorite FROM UserFavoriteArtist GROUP BY ArtistId) T2 ON T0.Id = T2.ArtistId
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Observed FROM UserObservedArtist GROUP BY ArtistId) T3 ON T0.Id = T3.ArtistId";

            var query = _dbContext.ArtistRatingAverage.FromSqlRaw(sql);

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
                    query = query.OrderBy(prp => prp.ObservedCount);
                    break;
                case RankSortType.ReviewsDesc:
                    query = query.OrderByDescending(prp => prp.ObservedCount);
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

        public async Task<bool> DoesArtistWithNameExistsAsync(string name)
        {
            return await _dbContext.Artist.AnyAsync(prp => string.Equals(prp.Name, name));
        }
    }
}
