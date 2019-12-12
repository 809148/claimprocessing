namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure.DTOs
{
    public class BenefitResDto
    {
        public string SubscriberId { get; set; }
        public string MemberId { get; set; }
        public CoverageTypeForGet CoverageType { get; set; }
        public string DateOfService { get; set; }

        public string EligStatus { get; set; }
    }
}
