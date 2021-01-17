using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Moq;
using Persistence.Repository.Abstract;
using AutoMapper;
using AttensiTechTestApi.Services.Abstract;
using AttensiTechTestApi.Services;
using Persistence.Model;
using Common.Dto;

namespace UnitTests.AttensiTechTestApi.Services
{
    public class PlayerServiceTests
    {
        private Mock<IPlayerRepository> _repositoryServiceMock;
        private Mock<IMapper> _mapperMock;
        private PlayerService _playerService;
        private PlayerModel newPlayerModel = new PlayerModel { Id = 16, Name = "Paul" };
        private PlayerDto newPlayerDto = new PlayerDto { Id = 16, Name = "Paul" };

    public PlayerServiceTests()
        {

        }

        [SetUp]
        public void SetUp()
        {
            _repositoryServiceMock = new Mock<IPlayerRepository>();
            _mapperMock = new Mock<IMapper>();

            _playerService = new PlayerService(_repositoryServiceMock.Object, _mapperMock.Object);
            _mapperMock.Setup(s => s.Map<PlayerModel, PlayerDto>(It.IsAny<PlayerModel>())).Returns(newPlayerDto);
        }

        [Test]
        public void CreateNewPlayer_PlayerIsEmpty_ThrowError()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _playerService.CreatePlayer(null));
        }

        [Test]
        public void CreateNewPlayer_NewPlayerCreated_ReturnsPlayerId()
        {
            _repositoryServiceMock.Setup(s => s.CreateNewPlayerAsync(It.Is<CreatePlayerDto>(i => i.Name == "Paul"))).ReturnsAsync(newPlayerModel.Id);;
            _repositoryServiceMock.Setup(s => s.GetPlayerById(16)).ReturnsAsync(newPlayerModel);
            var newPlayer = new CreatePlayerDto { Name = "Paul" };
            
            var result = _playerService.CreatePlayer(newPlayer).Result;

            Assert.AreEqual(result.Id, newPlayerModel.Id);
            Assert.AreEqual(result.Name, newPlayerModel.Name);
        }

        [Test]
        public void GetPlayerById_ReturnsPlayer()
        {
            var id = 16;

            var result = _playerService.GetPlayerById(id).Result;

            Assert.AreEqual(result.Id, newPlayerModel.Id);
            Assert.AreEqual(result.Name, newPlayerModel.Name);
        }

        [Test]
        public void GetPlayerById_IdIsNull_ThrowsError()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _playerService.GetPlayerById(0));
        }


    }
}
