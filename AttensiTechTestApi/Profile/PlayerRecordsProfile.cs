using Common.Dto;
using Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttensiTechTestApi.Profile
{
    public class PlayerRecordsProfile : AutoMapper.Profile
    {
        public PlayerRecordsProfile()
        {
            CreateMap<PlayerRecordDto, PlayerRecordModel>();
            CreateMap<PlayerRecordModel, PlayerRecordDto>();
        }
    }
}
