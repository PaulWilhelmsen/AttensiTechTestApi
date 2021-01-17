using Common.Dto;
using Persistence.Model;


namespace AttensiTechTestApi.Profile
{
    public class PlayerProfile : AutoMapper.Profile 
    {
        public PlayerProfile()
        {
            CreateMap<CreatePlayerDto, PlayerModel>();
            
            CreateMap<PlayerDto, PlayerModel>();
            CreateMap<PlayerModel, PlayerDto>();
        }
    }
}
