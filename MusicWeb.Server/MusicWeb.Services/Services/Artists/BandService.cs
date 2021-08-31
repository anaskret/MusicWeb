using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Artists
{
    public class BandService : IBandService
    {
        private readonly IBandRepository _bandRepository;

        public BandService(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task AddAsync(BandMember entity)
        {
            await _bandRepository.AddAsync(entity);
        }

        public async Task<List<BandMember>> GetBandMembersAsync(int id)
        {
            return await _bandRepository.GetBandMembersAsync(id);
        }
    }
}
