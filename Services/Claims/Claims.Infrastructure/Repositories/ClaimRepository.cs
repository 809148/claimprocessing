using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private ClaimDataContext _context;
        public ClaimRepository(ClaimDataContext context)
        {
            _context = context;
            BuildInMemoryData();
        }

       

        public int Create(Claim claim)
        {
            _context.Claims.Add(claim);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var claimToBeDeleted = _context.Claims.Find(id);
            _context.Claims.Remove(claimToBeDeleted);
           return _context.SaveChanges();
        }

        public IEnumerable<Claim> GetAll()
        {
           return  _context.Claims
                .Include(c=> c.Details)
                .ToList();
        }

        public Claim GetById(int id)
        {
            return _context.Claims.Find(id);
        }

        public Claim GetByMemberId(string memberId)
        {
            return _context.Claims.FirstOrDefault(c=> c.MemberIdentifier == memberId);
        }

        public Claim GetByMemberId(string memberId, string status)
        {
            return _context.Claims.FirstOrDefault(c => c.MemberIdentifier == memberId && c.ClaimStatus == status);
        }

        public int Update(Claim claim)
        {
            var claimToBeUpdated = _context.Claims.Find(claim.Id);
            claimToBeUpdated = claim;
           return  _context.SaveChanges();
        }

        private void BuildInMemoryData()
        {
           
            //default Claims:
            var claimDetail1 = new ClaimDetail { Code = "Detail1", DiagCode="Diag1", UnitPrice=80, Quantity=2, Value=160, ServiceStartDate= "2019-09-01", ServiceEndDate="2019-09-30", DiagText="Diag1 Text", ProcCode="proccode" };
            var claimDetail2 = new ClaimDetail { Code = "Detail2", DiagCode = "Diag2", UnitPrice = 40, Quantity = 2, Value = 80, ServiceStartDate = "2019-08-01", ServiceEndDate = "2019-08-30", DiagText = "Diag2 Text", ProcCode = "proccode" };

            var claim1 = new Claim { ApprovedAmount = 100, BeneficiaryName = "Raj", ClaimStatus = "Pending", ClaimSubmissionDate = "2019-10-14", CoverageTypeCode = "Medical", MemberIdentifier = "MEM1001", PatientAddress = "#2, Royal homes layout, singasandra, Bengalurue 560068", PatientGender = "Male", ProviderName = "NH Bengaluru", ProviderId=1, Name = "NA", Relationship = "Self", SubscriberId = "MEM1001", SubscriberName = "", TotalValue = 160, DenialReason = string.Empty, Details=new List<ClaimDetail> { claimDetail1 } };

            var claim2 = new Claim { ApprovedAmount = 70, BeneficiaryName = "Jai", ClaimStatus = "Pending", ClaimSubmissionDate = "2019-10-01", CoverageTypeCode = "Medical", MemberIdentifier = "MEM1002", PatientAddress = "#2, Royal homes layout, singasandra, Bengalurue 560068", PatientGender = "Male", ProviderName = "NH Bengaluru", ProviderId = 1, Name = "NA", Relationship = "Self", SubscriberId = "MEM1002", SubscriberName = "", TotalValue = 80, DenialReason = string.Empty, Details = new List<ClaimDetail> { claimDetail2 } };

            if (!_context.Claims.Any())
            {
                _context.Claims.AddRange
                    (
                    claim1,claim2
                    );
                _context.SaveChanges();
            }
        }
    }
}
