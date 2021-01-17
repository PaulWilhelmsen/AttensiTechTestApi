using Persistence.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstract
{
    public interface ISummaryRepository
    {
        Task<List<WeeklySummaryModel>> WeeklyReportOnWeekNumberAsync(DateTime startDate, DateTime endDate);
    }
}