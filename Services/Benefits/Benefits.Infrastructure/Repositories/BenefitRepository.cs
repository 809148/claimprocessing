using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate;
using System.Collections.Generic;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Infrastructure.Repositories
{
    public class BenefitRepository : IBenefitRepository
    {
        private BenefitDataContext _context;

        public BenefitRepository(BenefitDataContext context)
        {
            _context = context;
            BuildInMemoryData();
        }

        public IEnumerable<Benefit> GetAll()
        {

            return _context.Benefits.ToList();
        }

        public Benefit GetBenefit(Benefit benefit)
        {
            var benefitObj = _context.Benefits.FirstOrDefault(b => b.SubscriberId == benefit.SubscriberId && b.MemberId == benefit.MemberId && b.DateOfService == benefit.DateOfService);
            return benefitObj;
        }

        public Benefit GetById(string benefitId)
        {
            return _context.Benefits.Find(int.Parse(benefitId));
        }

        private void BuildInMemoryData()
        {
            //default plan:
            var planDetails1 = new PlanDetail { ServiceCode = "Plan Detail - 1", ServiceName="Surgery One" };
            var planDetails2 = new PlanDetail {ServiceCode = "Plan Detail - 2" , ServiceName="Surgery Two"};
            var planDetails3 = new PlanDetail {  ServiceCode = "Plan Detail - 3", ServiceName = "Surgery Three" };
            var planDetails4 = new PlanDetail { ServiceCode = "Plan Detail - 4", ServiceName = "Surgery Four" };
            var planOne = new Plan {Name = "Plan - One", CoPayPercent=10, CoverageType="Medical", DeductiblePercent=50, EffectiveStartDate="2019-10-10", EffectiveEndDate="2020-10-09" };
            planOne.PlanDetails.Add(planDetails1);
            planOne.PlanDetails.Add(planDetails2 );
            var planTwo = new Plan {  Name = "Plan - Two", CoPayPercent = 20, CoverageType = "Medical", DeductiblePercent = 40, EffectiveStartDate = "2019-11-20", EffectiveEndDate = "2020-11-19" };
            planTwo.PlanDetails.Add(planDetails3);
            planTwo.PlanDetails.Add(planDetails4);
            var coverageTypeOne = new CoverageType {Name = "Medical", Plans = new List<Plan>() { planOne } };
            var coverageTypeTwo = new CoverageType { Name = "Other", Plans = new List<Plan>() { planTwo } };
            if (!_context.Benefits.Any())
            {
                _context.Benefits.AddRange
                    (
                    new Benefit {Plan=planOne, MemberId = "12345", SubscriberId = "1001", DateOfService = "2019-08-10", EligStatus = "eligible", CoverageType=coverageTypeOne }
                    , new Benefit {Plan=planTwo, MemberId = "12346", SubscriberId = "1002", DateOfService = "2019-08-15", EligStatus = "eligible",  CoverageType = coverageTypeTwo }
                    );
              
            }

            _context.SaveChanges();
        }
    }
}
