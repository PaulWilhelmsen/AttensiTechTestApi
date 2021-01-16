using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttensiTechTestApi.Services.Abstract;
using Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Model;

namespace AttensiTechTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<PlayerDto> Test()
        {
            return await _playerService.GetPlayerById(16);
        }
        // POST: api/Player
        [HttpPost]
        public async Task<PlayerDto> Post(CreatePlayerDto playerModel)
        {
            var newPlayer = await _playerService.CreatePlayer(playerModel);
            return newPlayer;
        }
    }
}
