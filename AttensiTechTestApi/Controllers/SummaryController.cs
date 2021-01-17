using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService _summaryService;
        public SummaryController(ISummaryService summaryService)
        {
            _summaryService = summaryService ?? throw new ArgumentNullException(nameof(summaryService));
        }
        //Weekly summary
        [HttpGet]
        public async Task<List<WeeklySummaryDto>> GetWeeklySummaryByWeekNr([Required]int weeknr)
        {
            var summary = await _summaryService.GetWeeklySummary(weeknr);
            
            return summary;
        }

        //Impact Report
    }
}