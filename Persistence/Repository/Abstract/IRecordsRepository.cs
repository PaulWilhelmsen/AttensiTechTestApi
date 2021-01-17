using Common.Dto;
using Persistence.Model;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstract
{
    public interface IRecordsRepository
    {
        Task<int> CreateNewPlayerRecord(CreatePlayerRecordDto newRecord);
        Task<PlayerRecordModel> GetPlayerRecordById(int id);
    }
}