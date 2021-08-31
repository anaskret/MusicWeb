using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Artists
{
    public class ArtistGenreRepository : Repository<ArtistGenre>, IArtistGenreRepository
    {
        public ArtistGenreRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
