using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Claims.Api.Infrastructure.Mappers
{
    public interface IValueResolver<in TSource, in TDestination, TDestMember>
    {
        TDestMember Resolve(TSource source, TDestination destination, TDestMember destMember, ResolutionContext context);
    }
    public class CustomResolver : IValueResolver<Claim, ClaimForGet, PatientForGet>
    {
        public PatientForGet Resolve(Claim source, ClaimForGet destination, PatientForGet member, ResolutionContext context)
        {
            return new PatientForGet { Name = source.BeneficiaryName, Gender = source.PatientGender, Address = source.PatientAddress };
        }
    }
}
