using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private IClaimRepository _repository;
        private ClaimDataContext _context;
        DbContextOptions<ClaimDataContext> _options;
        [SetUp]
        [Order(0)]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ClaimDataContext>()
               .UseInMemoryDatabase(databaseName: "Claims")
               .Options;

            _context = new ClaimDataContext(_options);
            _repository = new ClaimRepository(_context);
        }

        [Test]
        [Order(1)]
        public void GetAllClaimsTest()
        {
            var claims = _repository.GetAll();
            Assert.IsTrue(claims.Any());
        }

        [Test]
        [Order(2)]
        public void GetClaimByIdTest()
        {
            var claim = _repository.GetById(1);
            Assert.IsNotNull(claim);
        }

        [Test]
        [Order(3)]
        public void GetClaimByMemberIdTest()
        {
            var claim = _repository.GetByMemberId("MEM1001");
            Assert.IsNotNull(claim);
        }

        [Test]
        [Order(4)]
        public void GetClaimByMemberIdAndStatusTest()
        {

            var claim = _repository.GetByMemberId("MEM1001", "Pending");
            Assert.IsNotNull(claim);
        }

     

        [Test]
        [Order(5)]
        public void UpdateClaimTest()
        {
            var claim = _repository.GetByMemberId("MEM1001");
            claim.BeneficiaryName = "Akshay";
           var retValue= _repository.Update(claim);
            Assert.AreEqual(1, retValue);
            var updatedClaim = _repository.GetByMemberId("MEM1001");
            Assert.AreEqual("Akshay", updatedClaim.BeneficiaryName);
        }

        [Test]
        [Order(6)]
        public void DeleteClaimTest()
        {
            var claim = _repository.GetByMemberId("MEM1001");
            var retValue = _repository.Delete(claim.Id);
            Assert.AreEqual(1, retValue);
            var deletedClaim = _repository.GetByMemberId("MEM1001");
            Assert.IsNull(deletedClaim);
            var claims = _repository.GetAll();
            Assert.IsTrue(claims.Count() == 1);
        }

        [Test]
        [Order(7)]
        public void CreateClaimTest()
        {
            Claim claim = BuildClaim();
            var retValue = _repository.Create(claim);
            Assert.AreEqual(1, retValue);
            var claims = _repository.GetAll();
            Assert.IsTrue(claims.Count() == 2);
        }

        private Claim BuildClaim()
        {
           
            //default plan:
            var claimDetail1 = new ClaimDetail { ClaimDetailId = 1, Code = "Detail1", DiagCode = "Diag2", UnitPrice = 180, Quantity = 2, Value = 360, ServiceStartDate = "2019-09-01", ServiceEndDate = "2019-09-30", DiagText = "Diag2 Text", ProcCode = "proccode1" };
            var claim1 = new Claim { ApprovedAmount = 100, BeneficiaryName = "Vijay", ClaimStatus = "Pending", ClaimSubmissionDate = "2019-10-11", CoverageTypeCode = "Medical", MemberIdentifier = "MEM1010", PatientAddress = "#2, Royal homes layout, singasandra, Bengalurue 560068", PatientGender = "Male", ProviderName = "NH Bengaluru", Name = "NA", Relationship = "Self", SubscriberId = "MEM1010", SubscriberName = "", TotalValue = 260, DenialReason = string.Empty };

            return claim1;
            
        }
    }
}