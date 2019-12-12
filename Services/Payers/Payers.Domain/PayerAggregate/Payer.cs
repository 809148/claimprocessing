using Shared.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate
{
   public class Payer : Entity, IAggregateRoot
    {
        public Payer(string name, string address, string city, string state, string zip, string country)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name is required");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException("address is required");
            }

            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException("city is required");
            }

            if (string.IsNullOrEmpty(state))
            {
                throw new ArgumentNullException("state is required");
            }

            if (string.IsNullOrEmpty(zip))
            {
                throw new ArgumentNullException("zip is required");
            }

            if (string.IsNullOrEmpty(country))
            {
                throw new ArgumentNullException("country is required");
            }
            Name = name;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }
        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }
    }
}
