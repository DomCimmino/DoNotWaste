using AutoMapper;
using DoNotWaste.DTO;
using DoNotWaste.Models.AssetScoreModels;
using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EnergyStarProperty, BuildingDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PrimaryFunction, opt => opt.MapFrom(src => Enum.GetName(src.PrimaryFunction)))
            .ForMember(dest => dest.YearBuilt, opt => opt.MapFrom(src => src.YearBuilt))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => ConcatenateAddress(src.Address)))
            .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.GrossFloorArea!.Value))
            .ForMember(dest => dest.Occupancy, opt => opt.MapFrom(src => src.OccupancyPercentage))
            .ForMember(dest => dest.ConstructionStatus, opt => opt.MapFrom(src => Enum.GetName(src.ConstructionStatus)))
            .ReverseMap();
        CreateMap<EnergyStarMeterData, List<MeterDataDto>>()
            .ConvertUsing(src => src.MeterConsumptions != null 
                ? src.MeterConsumptions.Select(mc => new MeterDataDto
                {
                    StartDate = mc.StartDate,
                    EndDate = mc.EndDate,
                    Cost = mc.Cost,
                    Usage = mc.Usage
                }).ToList()
                : new List<MeterDataDto>());
        CreateMap<BuildingResponse, BuildingDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ConstructionStatus, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.HtmlUrl, opt => opt.MapFrom(src => src.HtmlUrl))
            .ReverseMap();
    }
    
    private static string ConcatenateAddress(EnergyStarAddress? address)
    {
        if (address == null)
        {
            return string.Empty;
        }

        var addressParts = new[]
        {
            address.FirstAddress,
            !string.IsNullOrEmpty(address.UsCanadaStateProvince) ? address.SecondAddress : string.Empty,
            address.City,
            !string.IsNullOrEmpty(address.UsCanadaStateProvince) ? address.UsCanadaStateProvince : address.OtherState,
            address.PostalCode,
            address.Country.ToString()
        };

        return string.Join(", ", addressParts.Where(part => !string.IsNullOrEmpty(part)));
    }
}