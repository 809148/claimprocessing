using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain.Seedwork;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate
{
    public class Benefit : Entity, IAggregateRoot
    {
        //[Key] //TODO: Verify
        public string SubscriberId { get; set; }
        public string MemberId { get; set; }
        public string DateOfService { get; set; }
        public string EligStatus { get; set; }

        [ForeignKey("CoverageTypeId")]
        public CoverageType CoverageType { get; set; }
        public int CoverageTypeId { get; set; }
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }
        public int PlanId { get; set; }
    }
}
