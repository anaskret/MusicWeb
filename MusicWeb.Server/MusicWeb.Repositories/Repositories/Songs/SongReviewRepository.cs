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
    public class SongReviewRepository : Repository<SongReview>, ISongReviewRepository
    {
        public SongReviewRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<SongReview> GetSongReviewFullDataByIdAsync(int id)
        {
            var entity = await _dbContext.SongReview
                .Include(user =>user.User)
                .Include(song => song.Song)
                .ThenInclude(album => album.Album)
                .ThenInclude(artist => artist.Artist)
                .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        
        public async Task<List<SongReviewRating>> GetSongsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15)
        {

           var sql = @$"SELECT SongReview.Id, SongReview.Title, SongReview.Content, SongReview.PostDate, SongReview.SongId, SongReview.UserId, 
           SongRating.Rating as Rating FROM SongReview
           LEFT JOIN SongRating
           ON SongReview.SongId = SongRating.SongId AND SongReview.UserId = SongRating.UserId";

           var query = _dbContext.SongReviewRating.FromSqlRaw(sql);

           query = query.Where(prp => prp.PostDate >= startDate && prp.PostDate <= endDate);
           switch (sortType)
           {
               case SortType.AlphabeticAsc:
                   query = query.OrderBy(prp => prp.Title);
                   break;
               case SortType.AlphabeticDesc:
                   query = query.OrderByDescending(prp => prp.Title);
                   break;
               case SortType.PopularityAsc:
                   query = query.OrderBy(prp => prp.Rating);
                   break;
               case SortType.PopularityDesc:
                   query = query.OrderByDescending(prp => prp.Rating);
                   break;
               default:
                   query = query.OrderBy(prp => prp.Title);
                   break;
           }

           query = query.Skip(pageNum * pageSize);
           query = query.Take(pageSize);

           var entities = await query.ToListAsync();
           return entities;
        }

        public async Task<List<SongReviewRating>> GetSongReviewsPagedAsync(int songId, int pageNum = 0, int pageSize = 15)
        {

            var sql = @$"SELECT AlbumReview.Id, AlbumReview.Title, AlbumReview.Content, AlbumReview.PostDate, AlbumReview.AlbumId, AlbumReview.UserId, AlbumRating.Rating as Rating FROM AlbumReview
            LEFT JOIN AlbumRating
            ON AlbumReview.AlbumId = AlbumRating.AlbumId AND AlbumReview.UserId = AlbumRating.UserId
            WHERE AlbumRating.AlbumId = '{songId}'";

            var query = _dbContext.SongReviewRating.FromSqlRaw(sql);
            query = query.OrderByDescending(prp => prp.PostDate);

            query = query.Skip(pageNum * pageSize);
            query = query.Take(pageSize);

            var entities = await query.ToListAsync();
            return entities;
        }
    }
}
