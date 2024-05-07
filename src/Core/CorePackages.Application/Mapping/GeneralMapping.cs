using AutoMapper;
using CorePackages.Application.Features.Commands;

namespace CorePackages.Application.Mapping;

public class GeneralMapping : Profile
{

    public GeneralMapping()
    {
        CreateMap<Domain.Entities.Configuration, Dto.ConfigurationDto>().ReverseMap();
        CreateMap<Domain.Entities.Configuration, CreateConfiguration>().ReverseMap();
        CreateMap<Domain.Entities.Configuration, CreateConfiguration>().ReverseMap();
    }

}
