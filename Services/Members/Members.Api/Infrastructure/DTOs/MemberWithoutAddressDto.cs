using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class MemberWithoutAddressDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
    }
}
