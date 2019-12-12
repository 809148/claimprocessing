using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.DTOs
{
    public class PayerForCreate
    {
        [Required(ErrorMessage = "Value required")]
        [DisplayName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Value required")]
        [DisplayName("address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Value required")]
        [DisplayName("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Value required")]
        [DisplayName("state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Value required")]
        [DisplayName("zip")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Value required")]
        [DisplayName("country")]
        public string Country { get; set; }
    }
}
