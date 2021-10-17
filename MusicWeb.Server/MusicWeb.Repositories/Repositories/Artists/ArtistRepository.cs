using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
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
                                             .Include(origin => origin.City)
                                             .ThenInclude(origin => origin.State)
                                             .ThenInclude(origin => origin.Country)
                                             .Include(albums => albums.Albums)
                                             .ThenInclude(genres => genres.AlbumGenre)
                                             .Include(band => band.Band)
                                             .ThenInclude(member => member.Member)
                                             .Include(comments => comments.ArtistComments).FirstOrDefaultAsync(prp => prp.Id == id);

            return entity;
        }

        public async Task GetArtistsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
            var query = GetAll();

            //query.Include(prp => prp)

            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(prp => prp.Name.Contains(searchString));
            if (startDate > DateTime.MinValue)
                query = query.Where(prp => prp.EstablishmentDate > startDate);
            if (endDate < DateTime.MaxValue)
                query = query.Where(prp => prp.EstablishmentDate < endDate);

            switch (sortType)
            {
                case SortType.AlphabeticAsc:
                    query.OrderBy(prp => prp.Name);
                    break;
                case SortType.AlphabeticDesc:
                    query.OrderByDescending(prp => prp.Name);
                    break;
                //case SortType.PopularityAsc: query.OrderBy(prp => prp.)
                default:
                    query.OrderBy(prp => prp.Name);
                    break;
            }

            query.Skip(pageNum * pageSize);
            query.Take(pageSize);
        }
    }
}
