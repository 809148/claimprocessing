using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.DTOs
{
    public class ProviderForGet
    {
        private readonly Provider _p;
        public ProviderForGet(Provider provider)
        {
            _p = provider;
        }
        [DisplayName("id")]
        public int Id { get { return _p.Id; } }

        [DisplayName("name")]
        public string Name { get { return _p.Name; } }

        [DisplayName("address")]
        public string Address { get { return _p.Address; } }

        [DisplayName("city")]
        public string City { get { return _p.City; } }

        [DisplayName("state")]
        public string State { get { return _p.State; } }


        [DisplayName("country")]
        public string Country { get { return _p.Country; } }

        [DisplayName("zip")]
        public int Zip { get { return _p.Zip; } }

        [DisplayName("registeredDate")]
        public string RegisteredDate { get { return _p.RegisteredDate; } }

        [DisplayName("type")]
        public ProviderTypeForGet Type { get { return new ProviderTypeForGet { Id = _p.ProviderTypeId, Type = _p.ProviderType !=null ? _p.ProviderType.Name:string.Empty }; } }

    }
}

