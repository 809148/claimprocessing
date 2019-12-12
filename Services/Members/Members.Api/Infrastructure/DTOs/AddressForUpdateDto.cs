using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class AddressForUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string AddressType { get; set; } //Home, Work etc.
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string State { get; set; }
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(100)]
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(6)]
        public string ZipCode { get; set; }

    }
}
