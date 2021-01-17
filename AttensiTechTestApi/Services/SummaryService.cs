using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Common.Dto;
using Persistence.Repository.Abstract;
using AutoMapper;
using Persistence.Model;
using AttensiTechTestApi.Services.Abstract;

namespace AttensiTechTestApi.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly ISummaryRepository _repository;
        private readonly IMapper _mapper;
        public SummaryService(ISummaryRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<WeeklySummaryDto>> GetWeeklySummary(int weekNumber)
        {
            var week = GetStartAndEndDateBasedOnWeek(weekNumber);
            var weeklySummary = await _repository.WeeklyReportOnWeekNumberAsync(week.startDate, week.endDate);

            var mappedWeeklySummary = _mapper.Map<List<WeeklySummaryModel>, List<WeeklySummaryDto>>(weeklySummary);
            return mappedWeeklySummary;
        }

        public (DateTime startDate, DateTime endDate) GetStartAndEndDateBasedOnWeek(int weekNumber)
        {
            //Should be an own class. 
            var startDate = ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday);
            var endDate = startDate.AddDays(6);

            return (startDate, endDate);
        }
    }
}
