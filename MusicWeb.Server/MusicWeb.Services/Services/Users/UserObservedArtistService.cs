using AutoMapper;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Users
{
    public class UserObservedArtistService : IUserObservedArtistService
    {
        private readonly IUserObservedArtistRepository _userObservedArtistRepository;

        public UserObservedArtistService(IUserObservedArtistRepository userObservedArtistRepository)
        {
            _userObservedArtistRepository = userObservedArtistRepository;
        }

        public async Task CreateAsync(UserObservedArtist entity)
        {
            entity.ObservedDate = DateTime.Now;
            await _userObservedArtistRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userObservedArtistRepository.GetByIdAsync(id);
            await _userObservedArtistRepository.DeleteAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _userObservedArtistRepository.DeleteRangeAsync(entities.ToList());
        }

        public async Task<IList<UserObservedArtist>> GetAllByUserIdAsync(string userId)
        {
            return await _userObservedArtistRepository.GetAllAsync(entity => entity.Where(prp => string.Equals(prp.UserId, userId)));
        }
    }
}
