using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Artists
{
    public interface IBandService
    {
        Task AddAsync(BandMember entity);
        Task<List<BandMember>> GetBandMembersAsync(int id);
    }
}
