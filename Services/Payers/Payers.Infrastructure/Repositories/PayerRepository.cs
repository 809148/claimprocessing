using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure.Repositories
{
    public class PayerRepository : IPayerRepository
    {
        private PayerDataContext _context;

        public PayerRepository(PayerDataContext context)
        {
            _context = context;
            BuildInMemoryData();
        }
        public int Create(Payer payer)
        {
            if (payer == null) return -1;
            _context.Payers.Add(payer);
            return _context.SaveChanges();
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payer> GetAll()
        {
           return  _context.Payers.ToList();
        }

        public Payer GetById(int id)
        {
            return _context.Payers.Find(id);
        }

        public int Update(Payer payer)
        {
            if (payer == null) return -1;
            var retrievePayer = _context.Payers.Find(payer.Id);
            retrievePayer = payer;
            return _context.SaveChanges();
        }

        private void BuildInMemoryData()
        {
            if (!_context.Payers.Any())
            {
                _context.Payers.AddRange
                    (
                    new Payer ("Tata AIG", "Royal homes layout Singasandra", "Bengaluru", "KA", "560068", "India"),
                    new Payer("ICICI Lombard", "HSR layout Singasandra", "Bengaluru", "KA", "560068", "India")
                    );
                _context.SaveChanges();
            }
        }
    }
}
