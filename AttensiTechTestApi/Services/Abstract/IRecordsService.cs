using Common.Dto;
using System.Threading.Tasks;

namespace AttensiTechTestApi.Services.Abstract
{
    public interface IRecordsService
    {
        Task<PlayerRecordDto> CreateNewPlayerRecordAsync(CreatePlayerRecordDto newRecord);
        Task<PlayerRecordDto> GetPlayerRecordByIdAsync(int id);
    }
}