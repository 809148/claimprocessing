using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.DTOs
{
    public class ProviderForCreate
    {
        [DisplayName("name")]
        [Required(ErrorMessage ="Value required")]
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
        [DisplayName("registeredDate")]
        public string RegisteredDate { get; set; }

        [DisplayName("type")]
        [Required(ErrorMessage = "Value required")]
        public string ProviderType { get; set; }

    }
}

