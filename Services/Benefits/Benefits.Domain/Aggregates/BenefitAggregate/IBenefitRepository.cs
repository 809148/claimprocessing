using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate
{
    public interface IBenefitRepository
    {
        Benefit GetById(string benefitId);

        Benefit GetBenefit(Benefit benefit);

        IEnumerable<Benefit> GetAll();
    }
}
