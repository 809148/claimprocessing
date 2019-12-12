using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Payer, PayerForGet>();
            CreateMap<PayerForCreate, Payer>();
            CreateMap<PayerForUpdate, Payer>();
        }
    }
}
