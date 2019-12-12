using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.Mappers;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Payers.Api.Controllers;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Tests
{
    public class PayersControllerTests
    {
        private IPayerRepository _repsoitory;
        private IMapper _mapper;
        private PayersController _controller;
        private DbContextOptions<PayerDataContext> _options;
        private PayerDataContext _context;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<PayerDataContext>()
                .UseInMemoryDatabase(databaseName: "myPayers")
                .Options;
            _context = new PayerDataContext(_options);
            _repsoitory = new PayerRepository(_context);
            

            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(c => c.AddProfile(mappingProfile));
            _mapper = new Mapper(configuration);

            _controller = new PayersController(_repsoitory, _mapper);
        }

        [Test]
        public void GetAllTests()
        {
            var result = _controller.GetAll();
            Assert.IsTrue(result.Result != null);
        }

        [Test]
        public void GetById()
        {
            var result = _controller.Get(1);
            Assert.IsTrue(result.Value != null);
            var payer = result.Value as PayerForGet;
            Assert.IsNotNull(payer);
            Assert.AreSame(payer.Name, "Tata AIG");
            Assert.AreEqual(payer.Address, "Royal homes layout Singasandra");
            Assert.AreEqual(payer.City, "Bengaluru");
            Assert.AreEqual(payer.State, "KA");
            Assert.AreEqual(payer.Zip, "560068");
        }
    }
}