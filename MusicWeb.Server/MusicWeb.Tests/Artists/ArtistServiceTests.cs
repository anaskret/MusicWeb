using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MusicWeb.Api;
using MusicWeb.Api.Extensions.DependencyResolver;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Identity;
using MusicWeb.Services.Interfaces.Origins;
using MusicWeb.Services.Services.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicWeb.Tests.Artists
{
    public class ArtistServiceTests
    {
        private Mock<IArtistRepository> _artistRepository;
        private Mock<IBandService> _bandService;
        private Mock<IMapper> _mapper;
        private Mock<IFileService> _fileService;
        private Mock<UserManager<ApplicationUser>> _userManager;
        private Mock<ISongService> _songService;
        private Mock<IConfiguration> _configuration;
        private Mock<AuthenticationStateProvider> _authenticationStateProvider;
        private Mock<IIdentityService> _identityService;
        private Mock<IEmailSender> _emailSender;

        public ArtistServiceTests()
        {
            _artistRepository = new Mock<IArtistRepository>();
            _mapper = new Mock<IMapper>();
            _bandService = new Mock<IBandService>();
            _fileService = new Mock<IFileService>();
            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            _songService = new Mock<ISongService>();
            _configuration = new Mock<IConfiguration>();
            _authenticationStateProvider = new Mock<AuthenticationStateProvider>();
            _identityService = new Mock<IIdentityService>();
            _emailSender = new Mock<IEmailSender>();
        }

        [Fact]
        public async Task AddArtist_ShouldAddNewBandMember()
        {
            _artistRepository
                .Setup(x => x.AddAsync(It.IsAny<Artist>()))
                .Returns(Task.FromResult((Artist)null))
                .Verifiable();
            _artistRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Artist()));
            _bandService
                .Setup(x => x.AddAsync(It.IsAny<BandMember>()))
                .Verifiable();
            _userManager
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((ApplicationUser)null))
                .Verifiable();
            _userManager
                .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((ApplicationUser)null))
                .Verifiable();
            _userManager
                .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .Verifiable();
            _mapper
                .Setup(x => x.Map<Artist>(It.IsAny<ArtistWithUserModel>()))
                .Returns((ArtistWithUserModel artist) =>
                {
                    var convertedArtist = new Artist
                    {
                        BandId = artist.BandId,
                        Type = ArtistType.BandMember
                    };
                    return convertedArtist;
                });

            var artistService = new ArtistService(
                _artistRepository.Object,
                _mapper.Object,
                _bandService.Object,
                _fileService.Object,
                _userManager.Object,
                _songService.Object,
                _configuration.Object,
                _authenticationStateProvider.Object,
                _identityService.Object,
                _emailSender.Object);

            var bandMember = new ArtistWithUserModel
            {
                Email = "test@gmail.com",
                UserName = "test",
                Type = ArtistType.BandMember,
                BandId = 1,
                ImageBytes = new byte[0]
            };

            await artistService.AddArtistAsync(bandMember);

            _artistRepository.Verify(x => x.AddAsync(It.IsAny<Artist>()), Times.Once);
            _artistRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _bandService.Verify(x => x.AddAsync(It.IsAny<BandMember>()), Times.Once);
            _userManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            _userManager.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Once);
            _userManager.Verify(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task AddArtist_EmailExists_ShouldThrowArgumentException()
        {
            _userManager
                .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ApplicationUser()))
                .Verifiable();

            var artistService = new ArtistService(
                _artistRepository.Object,
                _mapper.Object,
                _bandService.Object,
                _fileService.Object,
                _userManager.Object,
                _songService.Object,
                _configuration.Object,
                _authenticationStateProvider.Object,
                _identityService.Object,
                _emailSender.Object);

            var artist = new ArtistWithUserModel();

            Func<Task> act = async () => await artistService.AddArtistAsync(artist);

            await act
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Error User with given email already exists!");
            _userManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public async Task AddArtist_UserNameExists_ShouldThrowArgumentException()
        {
            _userManager
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ApplicationUser()))
                .Verifiable();
            _userManager
                .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((ApplicationUser)null))
                .Verifiable();

            var artistService = new ArtistService(
                _artistRepository.Object,
                _mapper.Object,
                _bandService.Object,
                _fileService.Object,
                _userManager.Object,
                _songService.Object,
                _configuration.Object,
                _authenticationStateProvider.Object,
                _identityService.Object,
                _emailSender.Object);

            var artist = new ArtistWithUserModel
            {
                Email = "test@gmail.com",
                UserName = "test",
                Type = ArtistType.BandMember,
                BandId = 1,
                ImageBytes = new byte[0]
            };

            Func<Task> act = async () => await artistService.AddArtistAsync(artist);

            await act
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Error User with given username already exists!");

            _userManager.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Once);
            _userManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
        }



        [Fact]
        public async Task AddArtist_WrongBandId_ShouldThrowArgumentException()
        {
            _artistRepository
                .Setup(x => x.AddAsync(It.IsAny<Artist>()))
                .Returns(Task.FromResult((Artist)null))
                .Verifiable();
            _artistRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((Artist)null));

            var artistService = new ArtistService(
                _artistRepository.Object,
                _mapper.Object,
                _bandService.Object,
                _fileService.Object,
                _userManager.Object,
                _songService.Object,
                _configuration.Object,
                _authenticationStateProvider.Object,
                _identityService.Object,
                _emailSender.Object);


            Func<Task> act = async () => await artistService.AddAsync(new Artist() { Type = ArtistType.BandMember }, Array.Empty<byte>());

            await act
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Incorrect BandId");

            _artistRepository.Verify(x => x.AddAsync(It.IsAny<Artist>()), Times.Once);
            _artistRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
