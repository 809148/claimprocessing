using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.DTOs
{
    public class MemberEligCheckDTO
    {
        [Required(ErrorMessage ="Required")]
        public string MemberIdentifier { get; set; }
        [Required(ErrorMessage = "Required")]
        public string SubscriberId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CoverageTypeCode { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ServiceStartDate { get; set; }
    }
}
