using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.BenefitAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure.Tests
{
    public class ProviderRepositoryTests
    {
        private IProviderRepository _repository;
        private ProviderDataContext _context;
        DbContextOptions<ProviderDataContext> _options;
        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ProviderDataContext>()
               .UseInMemoryDatabase(databaseName: "providers")
               .Options;

            _context = new ProviderDataContext(_options);
            _repository = new ProviderRepository(_context);
        }

        [Test]
        public void GetAll()
        {
            var payers = _repository.GetAll();
            Assert.IsTrue(payers.Any());
            Assert.IsTrue(payers.Any());
        }

        [Test]
        public void GetById()
        {
            int id = 1;
            var provider = _repository.GetById(id);
            Assert.IsNotNull(provider);
            Assert.AreEqual(provider.Id, 1);
            Assert.AreSame(provider.Name, "NH Bommansandra");
            Assert.AreEqual(provider.Address, "1234, Royal homes layout bommansandra, bengaluru");
            Assert.AreEqual(provider.City, "Bengaluru");
            Assert.AreEqual(provider.State, "KA");
            Assert.AreEqual(provider.Country, "India");
            // Assert.AreEqual(payer., "560068");
        }

        [Test]
        public void CannotGetByInvalidId()
        {
            int id = 100;
            var provider = _repository.GetById(id);
            Assert.IsNull(provider);
        }

        [Test]
        public void CanCreatePayer()
        {
            var provider = BuildProvider();
            var retValue = _repository.Create(provider);
            Assert.AreEqual(retValue, 1);
        }

        [Test]
        public void CanUpdateProvider()
        {
            var newProvider = BuildProvider("test provider");
            _repository.Create(newProvider);
            var latestProvider = _repository.GetAll().OrderByDescending(p => p.Id).FirstOrDefault();
            var provider = _repository.GetById(latestProvider.Id);
            if (provider == null) return;
            string name = "test provider";
            string address = "Changed Address";
            string city = "Changed City";
            string state = "Changed State";
            string country = "Changed Country";
            int zip = 456949;
            string type = "individual";
            provider.Name = name;
            provider.Address = address;
            provider.City = city;
            provider.State = state;
            provider.Country = country;
            provider.Zip = zip;
            provider.ProviderType = new ProviderType { Name = type };
            var retValue = _repository.Update(provider);
            Assert.AreEqual(retValue, 1);
            var modifiedProvider = _repository.GetById(latestProvider.Id);
            Assert.AreEqual(modifiedProvider.Name, name);
            Assert.AreEqual(modifiedProvider.Address, address);
            Assert.AreEqual(modifiedProvider.City, city);
            Assert.AreEqual(modifiedProvider.State, state);
           // Assert.AreEqual(modifiedprovider.Zip, zip);

        }

        private Provider BuildProvider()
        {
            return new Provider("NH bommanahalli", "HSR layout Singasandra", "Bengaluru", "KA","India",560100, "2010-11-24", "individual");
        }

        private Provider BuildProvider(string name)
        {
            return new Provider(name, "HSR layout Singasandra", "Bengaluru", "KA", "India",560068, "2010-11-24", "individual");
        }
    }
}