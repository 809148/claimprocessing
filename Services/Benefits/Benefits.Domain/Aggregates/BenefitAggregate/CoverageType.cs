using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate
{
    public class CoverageType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Plan> Plans { get; set; }
    }
}
