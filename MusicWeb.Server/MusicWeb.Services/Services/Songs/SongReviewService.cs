using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Services.Interfaces.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Songs
{
    public class SongReviewService : ISongReviewService
    {

        private readonly ISongReviewRepository _songReviewRepository;
        private readonly IMapper _mapper;


        public SongReviewService(ISongReviewRepository songReviewRepository, IMapper mapper)
        {
            _songReviewRepository = songReviewRepository;
            _mapper = mapper;
        }

        public async Task<SongReview> GetByIdAsync(int id)
        {
            return await _songReviewRepository.GetByIdAsync(id);
        }

        public async Task<List<SongReviewFullDataDto>> GetAllAsync()
        {
            return _mapper.Map<List<SongReviewFullDataDto>>(await _songReviewRepository.GetAllAsync(entity => entity.Include(user => user.User)
            .Include (song => song.Song)
            .ThenInclude(album => album.Album)
            .ThenInclude(artist => artist.Artist)));
        }

        public async Task AddAsync(SongReview entity)
        {
            await _songReviewRepository.AddAsync(entity);

        }

        public async Task UpdateAsync(SongReview entity)
        {
            await _songReviewRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _songReviewRepository.DeleteAsync(entity);
        }

        public async Task<SongReviewFullDataDto> GetSongReviewFullDataByIdAsync(int id)
        {
            var songReview = await _songReviewRepository.GetSongReviewFullDataByIdAsync(id);
            return _mapper.Map<SongReviewFullDataDto>(songReview);

        }

        public async Task<List<SongReviewRating>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = int.MaxValue)
        {
            var response = await _songReviewRepository.GetSongsPagedAsync(sortType, startDate, endDate, pageNum, pageSize);
            return _mapper.Map<List<SongReviewRating>>(response);
        }
        public async Task<List<SongReviewRating>> GetSongReviewsPagedAsync(int songId, int pageNum = 0, int pageSize = int.MaxValue)
        {
            var response = await _songReviewRepository.GetSongReviewsPagedAsync(songId, pageNum, pageSize);
            return _mapper.Map<List<SongReviewRating>>(response);
        }
    }
}

