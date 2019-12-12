using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        // Create a field to store the mapper object
        private readonly IMapper _mapper;
        private IBenefitRepository _repository;

        public BenefitsController(IBenefitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/benefits
        [HttpGet]
        public IEnumerable<BenefitResDto> GetAll()
        {
            var benefits = _repository.GetAll();
            if (!benefits.Any())
            {
                return null;
            }
            var benefitDtos = benefits.Select(x => _mapper.Map<BenefitResDto>(x));
            return benefitDtos;
        }

        // GET api/benefits/5
        [HttpGet("{benefitId}")]
        public ActionResult<BenefitResDto> GetById(string benefitId)
        {
            var benefit = _repository.GetById(benefitId);
            var benefitDto = _mapper.Map<BenefitResDto>(benefit);
            return benefitDto;
        }

        // GET api/benefits/
        [HttpPost]
        public ActionResult<BenefitResDto> Get(BenefitReqDto benefitRequest)
        {
            if (benefitRequest == null)
            {
                //return StatusCode(404, "invalid request");
                return null;
            }

            var benefit = _mapper.Map<BenefitReqDto, Benefit>(benefitRequest);
            var benefitReturnObj = _repository.GetBenefit(benefit);
            var benefitRes = _mapper.Map<BenefitResDto>(benefitReturnObj);
            return benefitRes;
        }
    }
}
