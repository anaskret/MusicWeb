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
    public class AlbumReviewRepository : Repository<AlbumReview>, IAlbumReviewRepository
    {
        public AlbumReviewRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<AlbumReview> GetAlbumReviewFullDataByIdAsync(int id)
        {
            var entity = await _dbContext.AlbumReview
                 .Include(user => user.User)
                 .Include(album => album.Album)
                 .ThenInclude(artist => artist.Artist)
                 .Include(rating => rating.Rating)
                 .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<List<AlbumReviewRating>> GetAlbumsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15)
        {

            var sql = @$"SELECT AlbumReview.Id, AlbumReview.Title, AlbumReview.Content, AlbumReview.PostDate, AlbumReview.AlbumId, AlbumReview.UserId, AlbumRating.Rating as Rating FROM AlbumReview
            LEFT JOIN AlbumRating
            ON AlbumReview.AlbumId = AlbumRating.AlbumId AND AlbumReview.UserId = AlbumRating.UserId";

            var query = _dbContext.AlbumReviewRating.FromSqlRaw(sql);

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
    }
}
