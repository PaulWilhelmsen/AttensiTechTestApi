using Common.Dto;
using Persistence.Model;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstract
{
    public interface IPlayerRepository
    {
        Task<int> CreateNewPlayerAsync(CreatePlayerDto newPlayer);
        Task<PlayerModel> GetPlayerById(int id);
    }
}