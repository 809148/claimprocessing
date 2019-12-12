using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate
{
    public interface IClaimRepository
    {
        Claim GetById(int id);
        IEnumerable<Claim> GetAll();
        int Create(Claim provider);
        int Update(Claim provider);
        int Delete(int id);
        Claim GetByMemberId(string memberId);
        Claim GetByMemberId(string memberId, string status);
    }
}
