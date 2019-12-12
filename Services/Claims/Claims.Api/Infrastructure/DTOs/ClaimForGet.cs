using System.Collections.Generic;
using System.ComponentModel;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Api.Infrastructure.DTOs
{
    public class ClaimForGet
    {
        public ClaimForGet()
        {

        }

        [DisplayName("patientDetail")]
        public PatientForGet PatientDetail { get; set; }
        //public string BeneficiaryName { get; set; }
        public string SubscriberId { get; set; }
        public string SubscriberName { get; set; }
        public string Relationship { get; set; }
        public string ProviderName { get; set; }
        public decimal TotalValue { get; set; }
        public string ClaimStatus { get; set; }
        public string MemberIdentifier { get; set; }
        public string CoverageTypeCode { get; set; }
        public string ClaimSubmissionDate { get; set; }
        public decimal ApprovedAmount { get; set; }
        public string DenialReason { get; set; }
        
        [DisplayName("details")]
        public ICollection<ClaimDetailForGet> Details { get; set; }
            = new List<ClaimDetailForGet>();
    }
}
