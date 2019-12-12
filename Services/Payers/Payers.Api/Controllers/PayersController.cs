using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Payers.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PayersController : ControllerBase
    {
        private readonly IPayerRepository _repository;
        private readonly IMapper _mapper;

        public PayersController(IPayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET api/payers
        [HttpGet]
        public ActionResult<IEnumerable<PayerForGet>> GetAll()
        {
            var payers = _repository.GetAll();
            var payerDtos = payers.Select(p => _mapper.Map<PayerForGet>(p));
            return Ok(payerDtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PayerForGet> Get(int id)
        {
            var payer = _repository.GetById(id);
            var payerDto = _mapper.Map<PayerForGet>(payer);
            return payerDto;
            //return Ok(payerDto);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
