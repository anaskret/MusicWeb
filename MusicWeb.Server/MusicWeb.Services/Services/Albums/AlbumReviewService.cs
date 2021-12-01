using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Services.Interfaces.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Albums
{
    public class AlbumReviewService: IAlbumReviewService
    {
        private readonly IAlbumReviewRepository _albumReviewRepository;
        private readonly IMapper _mapper;


        public AlbumReviewService(IAlbumReviewRepository albumReviewRepository, IMapper mapper)
        {
            _albumReviewRepository = albumReviewRepository;
            _mapper = mapper;
        }

        public async Task<AlbumReview> GetByIdAsync(int id)
        {
            return await _albumReviewRepository.GetByIdAsync(id);
           
        }

        public async Task<List<AlbumReviewFullDataDto>> GetAllAsync()
        {
            return _mapper.Map<List<AlbumReviewFullDataDto>>(await _albumReviewRepository.GetAllAsync(entity => entity
            .Include(user => user.User)
            .Include(album => album.Album)
            .ThenInclude(artist => artist.Artist)));
        }

        public async Task AddAsync(AlbumReview entity)
        {
            await _albumReviewRepository.AddAsync(entity);

        }

        public async Task UpdateAsync(AlbumReview entity)
        {
            await _albumReviewRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _albumReviewRepository.DeleteAsync(entity);
        }

        public async Task<AlbumReviewFullDataDto> GetAlbumReviewFullDataByIdAsync(int id)
        {
            var albumReview = await _albumReviewRepository.GetAlbumReviewFullDataByIdAsync(id);
            return _mapper.Map<AlbumReviewFullDataDto>(albumReview);

        }
    }
}
