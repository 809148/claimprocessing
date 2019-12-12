
using AutoMapper;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Filters;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Controllers
{
    [Route("api/v1/member")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberRepository _repository;
        private readonly IMapper _mapper;
        public MembersController(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/members
        [HttpGet]
        public IEnumerable<MemberForGetAllDto> GetAll()
        {
            var members = _repository.GetAll();
            if (!members.Any())
            {
                return null;
            }
            var memberDtos = members.Select(x => _mapper.Map<MemberForGetAllDto>(x));
            return memberDtos;
        }

        [HttpGet("newjoiners")]
        public IEnumerable<MemberForGetAllDto> NewJoiners()
        {
            var members = _repository.NewJoiners();
            if (!members.Any())
            {
                return null;
            }
            var memberDtos = members.Select(x => _mapper.Map<MemberForGetAllDto>(x));
            return memberDtos;
        }

        // GET api/members/5
        [HttpGet("{memberId}")]
        public ActionResult<MemberForGetByIdDto> GetById(int memberId)
        {
            var member = _repository.Get(memberId, true);
            var memberDto = _mapper.Map<MemberForGetByIdDto>(member);
            return memberDto;
        }


        // POST: api/Members
        [Route("enroll")]
        [HttpPost]
        public IActionResult Post([FromBody] MemberForCreationDto member)
        {
            if (member == null) return BadRequest("invalid member"); ; // exit if the member is null.
            var memberEntity = TranformMemberDto(member);
            var returnCode = _repository.Save(memberEntity);
            if (returnCode != 1) return Ok("member failed to save successfully");
            return Ok("member created successfully");
        }


        // PUT: api/MembersApi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MemberForCreationDto member)
        {
            if (id <= 0) return BadRequest("invalid id"); //exit if the id is not valid.
            if (member == null) return BadRequest("invalid member"); ; // exit if the member is null.
            var memberEntity = TranformMemberDto(member);
            //memberEntity.Id = id;
            var returnCode = _repository.Save(memberEntity);
            if (returnCode != 1) return Ok("member failed to update successfully");
            return Ok("member updated successfully");
        }
       
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var returnCode =_repository.Delete(id);
            if (returnCode != 1) return Ok("member failed to delete successfully");
            return Ok("member deleted successfully");
        }

        [ValidateModel]
        [HttpGet]
        [Route("checkElig")]
        public ActionResult CheckEligibility(MemberEligCheckDTO memberEligCheck)
        {
            var result = _repository.CheckEligibility(memberEligCheck.MemberIdentifier, memberEligCheck.SubscriberId, memberEligCheck.CoverageTypeCode, memberEligCheck.ServiceStartDate);
            return Ok(result);
        }

        ////private functions
        private Member TranformMemberDto(MemberForCreationDto member)
        {
            if (member == null) return null;
            var mEntity = new Member(member.Name.FirstName, member.Name.LastName, member.Name.MiddleName, member.Gender, member.DateOfBirth, member.MaritalStatus, member.CoverageStartDate, member.CoverageEndDate, member.CoverageTypeCode, member.Name.Prefix, member.Name.Suffix);
            if (member.Addresses.Any())
            {
                mEntity.Addresses = member.Addresses.Select(a => _mapper.Map<Address>(a)).ToList();
            }

            if (member.Contacts.Any())
            {
                mEntity.Contacts = member.Contacts.Select(a => _mapper.Map<Contact>(a)).ToList();
            }

            return mEntity;
        }
    }
}
