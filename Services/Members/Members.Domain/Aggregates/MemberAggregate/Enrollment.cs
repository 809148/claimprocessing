using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate
{
    public class Enrollment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int PlanId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [Required]
        public string CoverageType { get; set; }

        [Required]
        [MaxLength(50)]
        public string CoverageTypeCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string CoverageStartDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string CoverageEndDate { get; set; }
    }
}
