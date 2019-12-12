using Shared.Domain.Seedwork;
using System.ComponentModel.DataAnnotations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate
{
    public class ProviderType: Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
