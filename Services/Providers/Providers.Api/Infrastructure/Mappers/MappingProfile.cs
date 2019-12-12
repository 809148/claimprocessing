using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Provider, ProviderForGet>();
            CreateMap<ProviderForCreate, Provider>();
            CreateMap<ProviderType, ProviderTypeForGet>();
        }
    }
}
