using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.BenefitAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Providers.Api.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/v1/providers")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;
        public ProvidersController(IProviderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/Providers
        [HttpGet]
        public ActionResult<IEnumerable<ProviderForGet>> Get()
        {
            var providerEntities= _repository.GetAll();
            var providerDtos = providerEntities.Select(p => new ProviderForGet(p));
            return Ok(providerDtos);
        }

        // GET: api/Providers/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid request");
            var providerEntity = _repository.GetById(id);
            if(providerEntity == null) return BadRequest("Invalid request");
            var providerDto = new ProviderForGet(providerEntity);
            return Ok(providerDto);
        }

        // POST: api/Providers
        [HttpPost]
        public ActionResult Post([FromBody] ProviderForCreate providerDto)
        {
            if (providerDto == null) return BadRequest("Invalid request");
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request");
            }
            var providerEntity = _mapper.Map<Provider>(providerDto);
            if(providerEntity == null) return BadRequest("Invalid request");
            var retVal = _repository.Create(providerEntity);
            if (retVal != 1) return Ok("failed to save data, kindly verify your inputs");
            return Ok("new provider created succesfully");
        }

        // PUT: api/Providers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProviderForCreate providerDto)
        {
            if (providerDto == null) return BadRequest("Invalid request");
            if (id <= 0) return BadRequest("Invalid request");
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request");
            }
            var providerEntity = _mapper.Map<Provider>(providerDto);
            if (providerEntity == null) return BadRequest("Invalid request");
            var retVal = _repository.Update(providerEntity);
            if (retVal != 1) return Ok("failed to save data, kindly verify your inputs");
            return Ok("Data saved succesfully");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/Providers
        //[Route("api/providers/procedures")]
        [HttpGet("api/providers/{procedures}/", Name ="procedures")]
        public ActionResult<IEnumerable<ProviderForGet>> GetProcedures()
        {
            var providerEntities = _repository.GetAll();
            var providerDtos = providerEntities.Select(p => _mapper.Map<ProviderForGet>(p));
            return Ok(providerDtos);
            //return new string[] { "value1", "value2" };
        }
    }
}
