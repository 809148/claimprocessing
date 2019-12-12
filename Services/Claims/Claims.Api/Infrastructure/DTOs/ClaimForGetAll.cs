using System.Collections.Generic;
using System.ComponentModel;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Api.Infrastructure.DTOs
{
    public class ClaimForGetAll
    {
        [DisplayName("id")]
        public string Id { get; set; }

        [DisplayName("patientName")]
        public string PatientName { get; set; }

        [DisplayName("pateintGender")]
        public string PatientGender { get; set; }

        [DisplayName("patientAddress")]
        public string PatientAddress { get; set; }

        [DisplayName("beneficiaryName")]
        public string BeneficiaryName { get; set; }

        [DisplayName("subscriberName")]
        public string SubscriberId { get; set; }
        [DisplayName("subscriberName")]
        public string SubscriberName { get; set; }
        [DisplayName("relationship")]
        public string Relationship { get; set; }
        [DisplayName("providerName")]
        public string ProviderName { get; set; }
        [DisplayName("totalValue")]
        public decimal TotalValue { get; set; }
        [DisplayName("claimStatus")]
        public string ClaimStatus { get; set; }
       
        [DisplayName("memberIdentifier")]
        public string MemberIdentifier { get; set; }
        [DisplayName("coverageTypeCode")]
        public string CoverageTypeCode { get; set; }
        [DisplayName("claimSubmissionDate")]
        public string ClaimSubmissionDate { get; set; }
        [DisplayName("approvedAmount")]
        public decimal ApprovedAmount { get; set; }
        [DisplayName("denialReason")]
        public string DenialReason { get; set; }
        [DisplayName("providerId")]
        public int ProviderId { get; set; }
        [DisplayName("details")]
        public ICollection<ClaimDetailForGet> Details { get; set; }
            = new List<ClaimDetailForGet>();
    }
}
