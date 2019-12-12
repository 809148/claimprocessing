using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate
{
    public class ClaimDetail
    {
        [Key]
        public int ClaimDetailId { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public string ServiceStartDate { get; set; }
        public string ServiceEndDate { get; set; }
        public string DiagText { get; set; }
        public string DiagCode {get;set;}
        public string ProcCode { get; set; }
        public string ProcText { get; set; }

        [ForeignKey("ClaimId")]
        public Claim Claim { get; set; }
        public int ClaimId { get; set; }
    }
}
