using CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.DTOs;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class MemberForGetByIdDto
    {
        public MemberForGetByIdDto() { }

        [Display(Name = "memberId")]
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

        [Display(Name = "addresses")]
        public IEnumerable<AddressDto> Addresses { get; set; }

        [Display(Name = "contacts")]
        public IEnumerable<ContactDto> Contacts { get; set; }

        [Display(Name = "enrollments")]
        public IEnumerable<EnrollmentForGet> Enrollments { get; set; }

        [Display(Name = "joiningDate")]
        [MaxLength(10)]
        public string JoiningDate { get; set; }
    }
}
