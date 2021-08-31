using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Artists
{
    public interface IBandRepository : IRepository<BandMember>
    {
        Task<List<BandMember>> GetBandMembersAsync(int id);
    }
}
