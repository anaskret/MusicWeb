using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Artists
{
    public interface IArtistCommentService
    {
        Task AddAsync(ArtistComment entity);
        Task<IList<ArtistComment>> GetAllByArtistIdAsync(int id);
        Task<ArtistComment> GetByIdAsync(int id);
        Task UpdateAsync(ArtistComment entity);
        Task DeleteAsync(int id);
    }
}
