using System.ComponentModel;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Api.Infrastructure.DTOs
{
    public class ClaimDetailForGet
    {
        [DisplayName("claimDetailId")]
        public int ClaimDetailId { get; set; }

        [DisplayName("code")]
        public string Code { get; set; }

        [DisplayName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [DisplayName("quantity")]
        public int Quantity { get; set; }

        [DisplayName("value")]
        public decimal Value { get; set; }

        [DisplayName("serviceStartDate")]
        public string ServiceStartDate { get; set; }

        [DisplayName("serviceEndDate")]
        public string ServiceEndDate { get; set; }

        [DisplayName("diagcode")]
        public string DiagCode { get; set; }

        [DisplayName("diagtext")]
        public string DiagText { get; set; }

        [DisplayName("proccode")]
        public string ProcCode { get; set; }

        [DisplayName("proctext")]
        public string ProcText { get; set; }
     
    }
}
