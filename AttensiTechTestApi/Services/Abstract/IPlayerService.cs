using Common.Dto;
using System.Threading.Tasks;

namespace AttensiTechTestApi.Services.Abstract
{
    public interface IPlayerService
    {
        Task<PlayerDto> CreatePlayer(CreatePlayerDto newPlayer);
        Task<PlayerDto> GetPlayerById(int id);
    }
}