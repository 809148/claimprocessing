using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.DTOs
{
    public class PayerForGet
    {
        [DisplayName("name")]
        public string Name { get; set; }
        [DisplayName("address")]
        public string Address { get; set; }
        [DisplayName("city")]
        public string City { get; set; }
        [DisplayName("state")]
        public string State { get; set; }
        [DisplayName("zip")]
        public string Zip { get; set; }
        [DisplayName("country")]
        public string Country { get; set; }
    }
}
