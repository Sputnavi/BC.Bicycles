using AutoMapper;
using BC.Bicycles.Boundary.Request;
using BC.Bicycles.Boundary.Response;
using BC.Bicycles.Models;

namespace BC.Bicycles.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bicycle, BicycleForReadModel>();
        CreateMap<BicycleForCreateOrUpdateModel, Bicycle>().ReverseMap();
        CreateMap<BicycleForReadModel, BicycleForCreateOrUpdateModel>();
    }
}