using Common.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttensiTechTestApi.Services.Abstract
{
    public interface ISummaryService
    {
        (DateTime startDate, DateTime endDate) GetStartAndEndDateBasedOnWeek(int weekNumber);
        Task<List<WeeklySummaryDto>> GetWeeklySummary(int weekNumber);
    }
}