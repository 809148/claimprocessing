using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
           // CreateMap<Member, MemberForGetAllDto>();
            CreateMap<MemberForGetAllDto, Member>();
            CreateMap<Member, MemberWithoutAddressDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<AddressForCreationDto, Address>();
            CreateMap<AddressForUpdateDto, Address>();
            CreateMap<MemberForCreationDto, Member>();
            CreateMap<AddressForCreationDto, Address>();
            CreateMap<ContactForCreateDto, Contact>();
            CreateMap<Contact, ContactDto>();
            CreateMap<Enrollment, EnrollmentForGet>();
            CreateMap<EnrollmentForCreate, Enrollment>();

            CreateMap<Member, MemberForGetAllDto>()
                .ForMember(dest=> dest.MemberId, opt=> opt.MapFrom(p=> p.Id))  
                .ForMember(dest => dest.Name, opt => opt.MapFrom(p => new Name { Prefix = p.Prefix, FirstName = p.FirstName, LastName = p.LastName, MiddleName=p.MiddleName, Suffix=p.Suffix }))
                   .ForMember(dest => dest.Addresses, opt => opt.MapFrom(d => d.Addresses))
                   .ForMember(dest => dest.Contacts, opt => opt.MapFrom(d => d.Contacts))
                   .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(d => d.Enrollments));

            CreateMap<Member, MemberForGetByIdDto>()
                 .ForMember(dest => dest.MemberId, opt => opt.MapFrom(p => p.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(p => new Name { Prefix = p.Prefix, FirstName = p.FirstName, LastName = p.LastName, MiddleName = p.MiddleName, Suffix = p.Suffix }))
                  .ForMember(dest => dest.Addresses, opt => opt.MapFrom(d => d.Addresses))
                  .ForMember(dest => dest.Contacts, opt => opt.MapFrom(d => d.Contacts))
                  .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(d => d.Enrollments));

            CreateMap<MemberForCreationDto, Member>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(d => d.Addresses))
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(d => d.Contacts))
              ;
        }
    }
}
