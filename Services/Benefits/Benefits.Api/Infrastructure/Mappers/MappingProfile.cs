using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            //CreateMap<Benefit, BenefitResDto>();
            CreateMap<BenefitReqDto, Benefit>();
            CreateMap<CoverageType, CoverageTypeForGet>();
            CreateMap<Benefit, BenefitResDto>()
                 .ForMember(dest => dest.CoverageType, opt => opt.MapFrom(p => new CoverageTypeForGet { Id = p.CoverageType.Id, Type = p.CoverageType.Name }));
        }
    }
}
