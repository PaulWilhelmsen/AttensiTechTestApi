using Common.Dto;
using Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Extensions;

namespace AttensiTechTestApi.Profile
{
    public class WeeklySummaryProfile : AutoMapper.Profile
    {
        public WeeklySummaryProfile()
        {
            CreateMap<WeeklySummaryModel, WeeklySummaryDto>()
                .ForMember(dest => dest.TotalTimeSpent, opt => opt.MapFrom(src => src.TotalTimeSpent.FromMinutesToHours()));
        }
    }
}
