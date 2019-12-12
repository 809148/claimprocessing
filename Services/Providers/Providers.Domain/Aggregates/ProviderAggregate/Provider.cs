using Shared.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate
{
    public class Provider : Entity, IAggregateRoot
    {
        public Provider()
        {
        }
        public Provider(string name, string address, string city, string state, string country,int zip, string registeredDate, string providerType)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name);
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(address);
            }

            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(city);
            }

            if (string.IsNullOrEmpty(state))
            {
                throw new ArgumentNullException(state);
            }

            if (string.IsNullOrEmpty(country))
            {
                throw new ArgumentNullException(country);
            }


            if (zip <=0)
            {
                throw new ArgumentNullException("zip");
            }

            if (string.IsNullOrEmpty(registeredDate))
            {
                throw new ArgumentNullException(registeredDate);
            }

            if (string.IsNullOrEmpty(providerType))
            {
                throw new ArgumentNullException("provider type", "provider type cannot be null.");
            }
            Name = name;
            Address = address;
            City = city;
            State = state;
            RegisteredDate = registeredDate;
            ProviderType = new ProviderType { Name = providerType };
            Country = country;
            Zip = zip;
        }
        [Required(ErrorMessage ="Required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(10)]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(10)]
        public string RegisteredDate { get; set; }

        [ForeignKey("ProviderTypeId")]
        public ProviderType ProviderType { get; set; }

        [Required(ErrorMessage = "Required")]
        public int ProviderTypeId { get; set; }
    
    }
}
