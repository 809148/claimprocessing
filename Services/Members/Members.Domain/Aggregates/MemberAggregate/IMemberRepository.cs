using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate
{
    public interface IMemberRepository
    {
        List<Member> GetAll();

        List<Member> NewJoiners();

        int Save(Member member);
        Member Get(int memberId, bool includeAddress = false);
        bool IsExists(int memberId);
        Address GetAddressForAMember(int memberId, int addressId);
        int Delete(int memberId);
        bool CheckEligibility(string memberIdentifier, string subscriberId, string coverageTypeCode, string serviceStartDate);
    }
}
