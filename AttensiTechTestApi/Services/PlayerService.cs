using AttensiTechTestApi.Services.Abstract;
using AutoMapper;
using Common.Dto;
using Persistence.Model;
using Persistence.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttensiTechTestApi.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        //Create player
        public async Task<PlayerDto> CreatePlayer(CreatePlayerDto newPlayer)
        {
            if (newPlayer is null)
                throw new ArgumentNullException(nameof(newPlayer));
                        
            var id = await _playerRepository.CreateNewPlayerAsync(newPlayer);
            var newlyCreatedPlayer = await GetPlayerById(id);

            return newlyCreatedPlayer;
        }

        //Get Player
        public async Task<PlayerDto> GetPlayerById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException($"Id cannot be null when getting player by id | class: {nameof(PlayerService)}");

            var player = await _playerRepository.GetPlayerById(id);
            var mappedPlayer = _mapper.Map<PlayerModel, PlayerDto>(player);

            return mappedPlayer;
        }

    }
}
