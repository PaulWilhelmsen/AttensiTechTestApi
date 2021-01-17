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
    public class RecordsService : IRecordsService
    {
        private readonly IRecordsRepository _recordsRepository;
        private readonly IMapper _mapper;
        public RecordsService(IRecordsRepository recordsRepository, IMapper mapper)
        {
            _recordsRepository = recordsRepository ?? throw new ArgumentNullException(nameof(recordsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PlayerRecordDto> CreateNewPlayerRecordAsync(CreatePlayerRecordDto newRecord)
        {
            var newRecordId = await _recordsRepository.CreateNewPlayerRecord(newRecord);
            var newPlayer = await GetPlayerRecordByIdAsync(newRecordId);

            return newPlayer;
        }

        public async Task<PlayerRecordDto> GetPlayerRecordByIdAsync(int id)
        {
            var playerRecord = await _recordsRepository.GetPlayerRecordById(id);
            var mappedRecord = _mapper.Map<PlayerRecordModel, PlayerRecordDto>(playerRecord);

            return mappedRecord;
        }
    }
}
