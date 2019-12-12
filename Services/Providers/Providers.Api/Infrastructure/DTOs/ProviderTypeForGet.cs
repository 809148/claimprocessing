using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.DTOs
{
    public class ProviderTypeForGet
    {

        [DisplayName("id")]
        public int Id { get; set; }

        [DisplayName("type")]
        public string Type { get; set; }
    }
}
