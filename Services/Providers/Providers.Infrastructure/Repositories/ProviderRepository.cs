using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.BenefitAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private ProviderDataContext _context;

        public ProviderRepository(ProviderDataContext context)
        {
            _context = context;
            BuildInMemoryData();
        }

        public int Create(Provider provider)
        {
            if (provider == null) return -1;
            _context.Providers.Add(provider);
            var retCode =_context.SaveChanges();
            return 1;
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            var providerEntity = _context.Providers.Find(id);
            if (providerEntity == null) return -1;
            _context.Providers.Remove(providerEntity);
            return _context.SaveChanges();
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers
                .Include(p=> p.ProviderType)
                .ToList();
        }

        public Provider GetById(int id)
        {
           return _context.Providers
                .Include(a => a.ProviderType)
                .FirstOrDefault(p=> p.Id==id);
        }

        public int Update(Provider provider)
        {
            var providerToBeUpdated = _context.Providers.Find(provider.Id);
            providerToBeUpdated = provider;
            var retVal= _context.SaveChanges();
            if (retVal <= 0) return -1; //failed to save entity successfully.
            return 1;
        }

        private void BuildInMemoryData()
        {
            if (!_context.Providers.Any())
            {
                _context.Providers.AddRange
                    (
                    new Provider("NH Bommansandra", "1234, Royal homes layout bommansandra, bengaluru",  "Bengaluru" ,"KA","India",560100, "2019-09-27","Individual" )
                    , new Provider("NH HSR Layout", "93348, HSR layout singasandra, bengaluru", "Bengaluru", "KA","India",560068, "2017-09-27",  "Individual")
                    );

                _context.ProviderTypes.AddRange(new ProviderType { Name = "Individual" }, new ProviderType {Name = "Group" });
                _context.SaveChanges();
            }
        }
    }
}
