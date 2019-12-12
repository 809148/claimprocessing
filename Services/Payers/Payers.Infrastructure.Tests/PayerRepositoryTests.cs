using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure.Tests
{
    public class PayerRepositoryTests
    {
        private IPayerRepository _repository;
        private PayerDataContext _context;
        DbContextOptions<PayerDataContext> _options;
        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<PayerDataContext>()
               .UseInMemoryDatabase(databaseName: "myPayers")
               .Options;

            _context = new PayerDataContext(_options);
            _repository = new PayerRepository(_context);
        }

        [Test]
        public void GetAll()
        {
           var payers= _repository.GetAll();
            Assert.IsTrue(payers.Any());
            Assert.AreEqual(payers.Count(), 2);
        }

        [Test]
        public void GetById()
        {
            int id = 1;
            var payer = _repository.GetById(id);
            Assert.IsNotNull(payer);
            Assert.AreEqual(payer.Id, 1);
            Assert.AreSame(payer.Name, "Tata AIG");
            Assert.AreEqual(payer.Address, "Royal homes layout Singasandra");
            Assert.AreEqual(payer.City, "Bengaluru");
            Assert.AreEqual(payer.State, "KA");
            Assert.AreEqual(payer.Zip, "560068");
        }

        [Test]
        public void CannotGetByInvalidId()
        {
            int id = 100;
            var payer = _repository.GetById(id);
            Assert.IsNull(payer);
        }

        [Test]
        public void CanCreatePayer()
        {
            var payer = BuildPayer();
            var retValue = _repository.Create(payer);
            Assert.AreEqual(retValue, 1);
        }

        [Test]
        public void CanUpdatePayer()
        {
            int id = 1;
            var payer = _repository.GetById(id);
            if (payer == null) return;
            Assert.AreEqual(payer.Id, id);
            string name = "New Payer";
            string address = "Changed Address";
            string city = "Changed City";
            string state = "Changed State";
            string zip = "Changed Zip";
            payer.Name = name;
            payer.Address = address;
            payer.City = city;
            payer.State = state;
            payer.Zip = zip;
            var retValue = _repository.Update(payer);
            Assert.AreEqual(retValue, 1);
            var modifiedPayer = _repository.GetById(id);
            Assert.AreEqual(modifiedPayer.Name, name);
            Assert.AreEqual(modifiedPayer.Address, address);
            Assert.AreEqual(modifiedPayer.City, city);
            Assert.AreEqual(modifiedPayer.State, state);
            Assert.AreEqual(modifiedPayer.Zip, zip);

        }

        private Payer BuildPayer()
        {
            return new Payer("Star Plus", "HSR layout Singasandra", "Bengaluru", "KA", "560068", "India");
        }
    }
}