using Shared.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate
{
    public class Member: Entity, IAggregateRoot
    {
        private string _identifier;
        public Member()
        {
        }
        public Member(string fName, string lName, string mName,  string gender, string dob, string maritalStatus, string joiningDate, string endDate, string coverageTypeCode, string prefix = "Mr", string suffix = "")
        {
            if (string.IsNullOrEmpty(fName))
            {
                throw new ArgumentNullException(fName);
            }

            if (string.IsNullOrEmpty(lName))
            {
                throw new ArgumentNullException(lName);
            }

            if (string.IsNullOrEmpty(gender))
            {
                throw new ArgumentNullException(gender);
            }

            if (string.IsNullOrEmpty(dob))
            {
                throw new ArgumentNullException(dob);
            }

            if (string.IsNullOrEmpty(maritalStatus))
            {
                throw new ArgumentNullException(maritalStatus);
            }


            if (string.IsNullOrEmpty(joiningDate))
            {
                throw new ArgumentNullException(joiningDate);
            }


            if (string.IsNullOrEmpty(endDate))
            {
                throw new ArgumentNullException(endDate);
            }

            if (string.IsNullOrEmpty(coverageTypeCode))
            {
                throw new ArgumentNullException(coverageTypeCode);
            }
            Prefix = prefix;
            FirstName = fName;
            LastName = lName;
            MiddleName = mName;
            Suffix = suffix;
            Gender = gender;
            DateOfBirth = dob;
            MaritalStatus = maritalStatus;
            _identifier = GenerateMemberIdentifier();
            var enrollment = new Enrollment { PlanId = PlanId, CoverageTypeCode = coverageTypeCode, CoverageEndDate = endDate, CoverageStartDate = joiningDate, CoverageType = coverageTypeCode };
            Enrollments.Add(enrollment);
            JoiningDate = joiningDate; ;
            //CoverageStartDate = joiningDate;
            //CoverageEndDate = endDate;
            //CoverageTypeCode = coverageTypeCode;

        }

        [MaxLength(10)]
        public string MemberIdentifier
        {

            get {
                return _identifier; }
            set { _identifier = value; }
        }
        [MaxLength(10)]
        public string SubscriberId
        {
            get
            {
                return _identifier;
            }
            private set { }

        }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(10)]
        public string Prefix { get; set; }

        [MaxLength(10)]
        public string Suffix { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(10)]
        public string DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string MaritalStatus { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string CoverageTypeCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string JoiningDate { get; set; }

        //[Required]
        //[MaxLength(10)]
        //public string CoverageEndDate { get; set; }

        [Required]
        public int PlanId { get; set; }

        //[ForeignKey("PlanId")]
        //public Plan Plan { get; set; } //This need to be fetched from Benefit.

        public ICollection<Address> Addresses { get; set; }
              = new List<Address>();

        public ICollection<Contact> Contacts { get; set; }
             = new List<Contact>();

        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();


        private string GenerateMemberIdentifier()
        {
           return string.Format("MEM{0}", new Random().Next(100000));
        }
    }
}
