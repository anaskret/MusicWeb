using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
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

        public async Task<Song> GetSongFullDataByIdAsync(int id)
        {
            var entity = await _dbContext.Song
                .Include(album => album.Album)
                .Include(composer => composer.Composer)
                .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }
    }
}
