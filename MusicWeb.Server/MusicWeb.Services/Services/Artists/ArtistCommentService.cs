using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Artists
{
    public class ArtistCommentService : IArtistCommentService
    {
        private readonly IArtistCommentRepository _artistCommentRepository;

        public ArtistCommentService(IArtistCommentRepository artistCommentRepository)
        {
            _artistCommentRepository = artistCommentRepository;
        }

        public async Task AddAsync(ArtistComment entity)
        {
            await _artistCommentRepository.AddAsync(entity);
        }
    }
}
