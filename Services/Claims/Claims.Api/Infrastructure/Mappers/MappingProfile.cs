using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Claims.Api.Infrastructure.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ClaimDetail, ClaimDetailForGet>();
            CreateMap<Claim, ClaimForGet>()
            //  .ForMember(dest => dest.Details, act => act.MapFrom(src => src.Details));
          //var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Claim, ClaimForGet>()
                     .ForMember(dest => dest.PatientDetail, opt => opt.MapFrom(p => new PatientForGet { Address = p.PatientAddress, Gender = p.PatientGender, Name = p.BeneficiaryName }))
                     .ForMember(dest => dest.Details, opt => opt.MapFrom(d => d.Details)
                     );
            // var mapperNew = configuration.CreateMapper();
            // CreateMap(configuration);

            CreateMap<Claim, ClaimForGetAll>()
                   .ForMember(dest => dest.Details, opt => opt.MapFrom(d => d.Details)
                   );
        }
       
    }
}
