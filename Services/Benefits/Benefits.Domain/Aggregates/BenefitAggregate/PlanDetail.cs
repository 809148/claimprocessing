using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate
{
    public class PlanDetail
    {
        [Key]
        public int Id { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }
        public int PlanId { get; set; }
    }
}
