using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class MemberForCreationDto
    {
        public long Id { get { return 0; } }
        [Display(Name = "memberIdentifier")]
        public string MemberIdentifier { get; set; }

        [Display(Name = "subscriberId")]
        public string SubscriberId { get; set; }

        [Display(Name="name")]
        public Name Name { get; set; }

        [Display(Name = "gender")]
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

        string _joiningDate = DateTime.Today.ToString("yyyy-mm-dd");
        [Display(Name = "joiningDate")]
        [MaxLength(10)]
        public string JoiningDate
        {
            get { return _joiningDate; }
            set { _joiningDate = value; }
        }

        //[Display(Name = "enrollments")]
        //public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
