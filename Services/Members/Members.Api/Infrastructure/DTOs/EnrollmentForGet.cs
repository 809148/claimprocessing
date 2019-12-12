using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.DTOs
{
    public class EnrollmentForGet
    {
       
        [DisplayName("enrollmentId")]
        public int EnrollmentId { get; set; }

        [DisplayName("planId")]
        public int PlanId { get; set; }

        [DisplayName("memberId")]
        public int MemberId { get; set; }

        [DisplayName("coverageTypecode")]
        public string CoverageTypeCode { get; set; }

        [DisplayName("coverageStartDate")]
        public string CoverageStartDate { get; set; }

        [DisplayName("coverageEndDate")]
        public string CoverageEndDate { get; set; }
    }
}
