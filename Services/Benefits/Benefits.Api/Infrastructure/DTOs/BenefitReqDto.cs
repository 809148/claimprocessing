namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure.DTOs
{
    public class BenefitReqDto
    {
        public string SubscriberId { get; set; }
        public string MemberId { get; set; }
        public string coverageType { get; set; }
        public string DateOfService { get; set; }
    }
}
