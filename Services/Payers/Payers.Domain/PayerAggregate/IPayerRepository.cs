using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate
{
    public interface IPayerRepository
    {
        Payer GetById(int id);
        IEnumerable<Payer> GetAll();
        int Create(Payer  payer);
        int Update(Payer payer);
        int Delete(long id);
    }
}
