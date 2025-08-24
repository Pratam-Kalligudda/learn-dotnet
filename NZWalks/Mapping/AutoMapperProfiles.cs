using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<Region,UpdateRegionRequestDto>().ReverseMap();
            CreateMap<Region,AddRegionRequestDto>().ReverseMap();
        }
    }
}
