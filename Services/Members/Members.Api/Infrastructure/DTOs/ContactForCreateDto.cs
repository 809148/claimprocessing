using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class ContactForCreateDto
    {
        [Required]
        [MaxLength(10)]
        public string ContactType { get; set; }
        [Required]
        [MaxLength(50)]
        public string Value { get; set; }
    }
}
