using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string AddressType { get; set; } //Home, Work etc.
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(100)]
        public string AddressLine3 { get; set; }
        [Required]
        [MaxLength(6)]
        public string ZipCode { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        public int MemberId { get; set; }
    }
}
