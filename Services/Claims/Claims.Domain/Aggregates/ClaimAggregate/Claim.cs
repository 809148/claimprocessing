using Shared.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
/*
{
        "id": 14,
        "patientName": "John Smith",
        "pateintGender": "male",
        "patientAddress": "18 drown Dr, plano, tx, 06010",
        "beneficiaryName": "Carl Smith",
        "subscriberName": "John Smith",
        "relationship": "self",
        "providerName": "Dr David Gray",
        "totalValue": 160,
        "claimStatus": "REJECTED",
        "subscriberId": "MEM10001",
        "memberIdentifier": "MEM10001",
        "coverageTypeCode": "Medical",
        "claimSubmissionDate": "2019-08-08",
        "approvedAmount": 160,
        "denialReason": "MEMBER ELIGIBILITY EXPIRED",
        "claimDetailMod": [
            {
                "claimDetailId": 2,
                "code": "detail1",
                "unitPrice": 80,
                "quantity": 2,
                "value": 80,
                "serviceStartDate": "2019-08-08",
                "serviceEndDate": "2019-08-09",
                "diagtext": "diag1 text",
                "proccode": "proccdode",
                "proctext": "proc text",
                "diagcode": "diag1"
            }
        ]
    }
*/
namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate
{
   public class Claim: Entity, IAggregateRoot 
    {
        public string Name { get; set; }
        public string PatientGender { get; set; }
        public string PatientAddress { get; set; }
        public string BeneficiaryName { get; set; }
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
        public int ProviderId { get; set; }

        public ICollection<ClaimDetail> Details { get; set; }
            = new List<ClaimDetail>();
    }
}
