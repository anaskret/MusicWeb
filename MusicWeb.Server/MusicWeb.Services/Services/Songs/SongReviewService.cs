using AutoMapper;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
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

            public async Task<List<SongReviewDto>> GetAllAsync()
            {
                return _mapper.Map<List<SongReviewDto>>(await _songReviewRepository.GetAllAsync());
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
    }
}

