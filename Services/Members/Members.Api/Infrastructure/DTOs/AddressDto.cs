namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class AddressDto
    {
     
        public int Id { get; set; }
        public string AddressType { get; set; } //Home, Work etc.
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ZipCode { get; set; }
    }
}
