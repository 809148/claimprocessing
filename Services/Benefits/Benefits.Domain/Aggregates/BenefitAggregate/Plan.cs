using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CoPayPercent { get; set; } 
        public string CoverageType { get; set; }
        public decimal DeductiblePercent { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public ICollection<PlanDetail> PlanDetails { get; set; }
            = new List<PlanDetail>();
    }
}
