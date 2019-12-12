using System.ComponentModel;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class ContactDto
    {
        [DisplayName("id")]
        public int Id { get; set; }

        [DisplayName("contactType")]
        public string ContactType { get; set; }

        [DisplayName("value")]
        public string Value { get; set; }
    }
}
