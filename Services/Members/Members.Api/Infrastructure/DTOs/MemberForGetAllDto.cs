using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.DTOs;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class MemberForGetAllDto
    {

        [DisplayName("memberId")]
        public long MemberId { get; set; }

        [Display(Name = "memberIdentifier")]
        public string MemberIdentifier { get; set; }

        [Display(Name = "subscriberId")]
        public string SubscriberId { get; set; }

        [DisplayName("name")]
        public Name Name { get; set; }


        [Display(Name = "gender")]
        public string Gender { get; set; }

        [Display(Name = "dateOfBirth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "maritalStatus")]
        public string MaritalStatus { get; set; }

        [Display(Name = "joiningDate")]
        [MaxLength(10)]
        public string JoiningDate { get; set; }
      

        [Display(Name = "addresses")]
        public IEnumerable<AddressDto> Addresses { get; set; }
        //public IEnumerable<AddressDto> Addresses { get {
        //         var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressDto>().ConstructUsing(m => new AddressDto() {
        //        AddressLine1 = m.AddressLine1
        //        ,AddressLine2 = m.AddressLine2
        //        ,AddressLine3 = m.AddressLine3
        //        ,AddressType = m.AddressType
        //        ,City = m.City
        //        ,State = m.State
        //        ,Country = m.Country
        //        ,ZipCode = m.ZipCode
        //    }));
        //    var mapperNew = configuration.CreateMapper();
        //    var addressDtos = _member.Addresses.Select(x => mapperNew.Map<AddressDto>(x));
        //        return addressDtos;
        //    }
        //}

        [Display(Name = "contacts")]
        public IEnumerable<ContactDto> Contacts { get; set; }
        //public IEnumerable<ContactDto> Contacts { get {
        //           var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDto>().ConstructUsing(m => new ContactDto() {
        //        ContactType = m.ContactType
        //        ,Value = m.Value
        //    }));
        //    var mapperNew = configuration.CreateMapper();
        //    var contactDtos = _member.Contacts.Select(x => mapperNew.Map<ContactDto>(x));
        //        return contactDtos;
        //    }
        //}

        [Display(Name = "enrollments")]
        public IEnumerable<EnrollmentForGet> Enrollments { get; set; }
        //public IEnumerable<EnrollmentForGet> Enrollments 
        //    {
        //        get {
        //            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Enrollment, EnrollmentForGet>().ConstructUsing(m => new EnrollmentForGet() { EnrollmentId= m.Id, MemberId= m.MemberId, PlanId=m.PlanId }

        //            ));
        //            var mapperNew = configuration.CreateMapper();
        //            var enrollmentDtos = _member.Enrollments.Select(x => mapperNew.Map<EnrollmentForGet>(x));
        //            return enrollmentDtos;
        //        }
        //    }
    }
}
