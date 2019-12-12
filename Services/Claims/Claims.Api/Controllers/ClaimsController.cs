using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;
//using CTOCDE.HC.ClaimsProcessing.Services.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Claims.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        IClaimRepository _repository;
        private readonly IMapper _mapper;
        private Uri BaseEndpoint { get; set; }

        public ClaimsController(IClaimRepository repository, IMapper mapper)//, Uri baseEndpoint)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllClaimInfo")]
        public ActionResult GetAllClaimInfo()
        {
            var claimEntities = _repository.GetAll();
            var claimDtos = claimEntities.Select(c => _mapper.Map<Claim, ClaimForGetAll>(c));
            return Ok(claimDtos);
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var claims= _repository.GetAll();
            var claimDtos = claims.Select(x => _mapper.Map<Claim, ClaimForGet>(x));
            return Ok(claimDtos);
        }

        [HttpGet]
        [Route("getClaimModbyMemberId/{memberId}")]
        public ActionResult GetClaimByMemberId(string memberId)
        {
            var claim = _repository.GetByMemberId(memberId);
            _mapper.Map<Claim, ClaimForGet>(claim);
            return Ok(claim);
        }

        private bool CheckEligibility(string claim)
        {

            return false;
        }

        //////test method
        //private static async Task GetMembersAsync()
        //{
        //    var requestUri = $"http://localhost/api/member";
        //    var response = await HttpRequestFactory.Get(requestUri);

        //    Console.WriteLine($"Status: {response.StatusCode}");
        //    var outputModel = response.ContentAsType<List<object>>();
        //    //outputModel.ForEach(item =>
        //    //                Console.WriteLine("{0} - {1}", item.MemberId, item.MemberIdentifier));
        //}

    }

   
}