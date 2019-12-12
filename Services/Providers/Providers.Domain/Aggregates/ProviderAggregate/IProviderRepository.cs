using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.BenefitAggregate
{
   public interface IProviderRepository
    {
        Provider GetById(int id);
        IEnumerable<Provider> GetAll();
        int Create(Provider provider);
        int Update(Provider provider);
        int Delete(int id);
    }
}
