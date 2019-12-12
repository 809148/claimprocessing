using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class MemberForUpdateDto
    {
        public long Id { get; set; }

        [Display(Name = "memberIdentifier")]
        public string MemberIdentifier { get; set; }

        [Display(Name = "subscriberId")]
        public string SubscriberId { get; set; }

        /*
        [Display(Name = "prefix")]
        [MaxLength(10)]
        public string Prefix { get; set; }

        [Display(Name = "firstName")]
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "lastName")]
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Display(Name = "middleName")]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Display(Name = "suffix")]
        [MaxLength(10)]
        public string Suffix { get; set; }
        */

        [Display(Name = "name")]
        public Name Name { get; set; }

        [Display(Name = "gender")]
        [Required]
        public string Gender { get; set; }

        [Display(Name = "dateOfBirth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "maritalStatus")]
        public string MaritalStatus { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "coverageTypeCode")]
        public string CoverageTypeCode { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "coverageStartDate")]
        public string CoverageStartDate { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "coverageEndDate")]
        public string CoverageEndDate { get; set; }

        [Required]
        [Display(Name = "planId")]
        public int PlanId { get; set; }

        [Display(Name = "addresses")]
        public IEnumerable<AddressForCreationDto> Addresses { get; set; } = new List<AddressForCreationDto>();

        [Display(Name = "contacts")]
        public IEnumerable<ContactForCreateDto> Contacts { get; set; } = new List<ContactForCreateDto>();
    }
}
