using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string ContactType { get; set; }
        [Required]
        [MaxLength(50)]
        public string Value { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [Required]
        public int MemberId { get; set; }
    }
}
