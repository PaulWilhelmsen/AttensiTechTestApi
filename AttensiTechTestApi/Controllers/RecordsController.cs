using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttensiTechTestApi.Services.Abstract;
using Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttensiTechTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        public IRecordsService _service { get; set; }
        public RecordsController(IRecordsService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<PlayerRecordDto> CreateNewPlayerRecord(CreatePlayerRecordDto newPlayerRecord)
        {
            var newRecord = await _service.CreateNewPlayerRecordAsync(newPlayerRecord);
            
            return newRecord;
        }

        [HttpGet]
        public async Task<PlayerRecordDto> GetRecordById(int id)
        {
            return await _service.GetPlayerRecordByIdAsync(id);
        }
    }
}