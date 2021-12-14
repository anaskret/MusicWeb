using AutoMapper;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Song entity)
        {
            await _songRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _songRepository.DeleteAsync(entity);
        }

        public async Task<List<SongDto>> GetAllAsync()
        {
            return _mapper.Map<List<SongDto>>(await _songRepository.GetAllAsync());
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _songRepository.GetByIdAsync(id);
        }

        public async Task<SongFullDataDto> GetSongFullDataByIdAsync(int id)
        {
                var song = await _songRepository.GetSongFullDataByIdAsync(id);
                return _mapper.Map<SongFullDataDto>(song);
            
        }

        public async Task UpdateAsync(Song entity)
        {
            await _songRepository.UpdateAsync(entity);
        }

        public async Task<SongRatingAverage> GetSongRatingAverage(int id)
        {
            return _mapper.Map<SongRatingAverage>(await _songRepository.GetSongAverageRating(id));
        }

        public async Task<List<SongRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = int.MaxValue, string searchString = "")
        {
            var response = await _songRepository.GetSongsPagedAsync(sortType, startDate, endDate, pageNum, pageSize, searchString);
            return response;
        }

        public async Task<IPagedList<Song>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue)
        {
            return await _songRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(prp => prp.Name.Contains(searchString));

                return query.OrderByDescending(prp => prp.Name);
            });
        }




    }

}
