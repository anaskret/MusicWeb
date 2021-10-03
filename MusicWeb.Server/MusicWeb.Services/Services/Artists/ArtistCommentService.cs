﻿using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _artistCommentRepository.DeleteAsync(entity);
        }

        public async Task<List<ArtistComment>> GetAllByArtistIdAsync(int id)
        {
            return await _artistCommentRepository.GetAll().Where(prp => prp.ArtistId == id).ToListAsync();
        }

        public async Task<ArtistComment> GetByIdAsync(int id)
        {
            return await _artistCommentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ArtistComment entity)
        {
            await _artistCommentRepository.UpdateAsync(entity);
        }
    }
}
