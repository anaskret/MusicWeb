using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Artists
{
    public class BandRepository : Repository<BandMember>, IBandRepository
    {
        public BandRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<BandMember>> GetBandMembersAsync(int id)
        {
            return await _dbContext.BandMembers.Where(prp => prp.BandId == id).ToListAsync();
        }
    }
}
