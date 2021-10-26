using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task AddAsync(Genre entity)
        {
            await _genreRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _genreRepository.DeleteAsync(entity);
        }

        public async Task<IList<Genre>> GetAllAsync()
        {
            return await _genreRepository.GetAllAsync(prp => prp);
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Genre entity)
        {
            await _genreRepository.UpdateAsync(entity);
        }
    }
}
