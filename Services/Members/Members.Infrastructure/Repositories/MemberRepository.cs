using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private MemberDataContext _context;
        public MemberRepository(MemberDataContext context)
        {
            _context = context;
            BuildInMemoryData();
        }

        public List<Member> GetAll()
        {
            return _context.Members
                   .Include(a => a.Addresses)
                    .Include(c => c.Contacts)
                     .Include(c => c.Enrollments)
                .OrderBy(m => m.FirstName).ToList();
        }

        public List<Member> NewJoiners()
        {
            return _context.Members
                   .Include(a => a.Addresses)
                    .Include(c => c.Contacts)
                     .Include(c => c.Enrollments).OrderByDescending(m=> m.JoiningDate)
                .OrderBy(m => m.FirstName).Take(4).ToList();
        }

        public int Save(Member member)
        {
            if (member == null) return -10;

            if (member.Id > 0)
            {
                var existingMember = Get(member.Id);
                if (member == null) return -11; // invalid update

                existingMember.FirstName = member.FirstName;
                existingMember.LastName = member.LastName;
                existingMember.Prefix = member.Prefix;
                existingMember.DateOfBirth = member.DateOfBirth;
                existingMember.Contacts = member.Contacts;
                existingMember.Addresses = member.Addresses;
                existingMember.Enrollments = member.Enrollments;
                try
                {
                    _context.SaveChanges();
                    return 2;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExists(member.Id))
                    {
                        return -12;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            //find if member already found.
            if (_context.Members.Any(m => m.FirstName == member.FirstName && m.LastName == member.LastName && m.DateOfBirth == member.DateOfBirth))
            {
                return -1; //member already found with same fname, lname and dob.
            }

            //if address found
            if (!member.Addresses.Any())
            {
                return -2; //address not found
            }

            //if contacts found
            if (!member.Contacts.Any())
            {
                return -3; //address not found
            }
            try
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(member.Id))
                {
                    return -2;
                }
                else
                {
                    throw;
                }
            }
        }

        public Member Get(int memberId, bool includeAddress = true)
        {
            if (includeAddress)
            {
                return _context.Members
                    .Include(a => a.Addresses)
                    .Include(c => c.Contacts)
                     .Include(c => c.Enrollments)
                    .Where(m => m.Id == memberId).FirstOrDefault();

            }
            var member = _context.Members.Where(m => m.Id == memberId).FirstOrDefault();
            if (member == null) return null;
            member.Addresses = new List<Address>();
            return member;
        }

        public void AddAddressForMember(int memberId, Address address)
        {
            var member = Get(memberId, false);
            member.Addresses.Append(address);
            _context.SaveChanges();
        }

        public Address GetAddressForAMember(int memberId, int addressId)
        {
            return _context.Addresses
               .Where(a => a.MemberId == memberId && a.Id == addressId).FirstOrDefault();
        }

        public int Delete(int memberId)
        {
            if (memberId <= 0) return -1; //invalid memberId

            var member = Get(memberId);

            if (member == null) return -2;// member not found.

            try
            {
                _context.Remove(member);
                _context.SaveChanges();
                return 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(member.Id))
                {
                    return -12;
                }
                else
                {
                    throw;
                }
            }
        }

        public bool IsExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }

        public bool CheckEligibility(string memberIdentifier, string subscriberId, string coverageTypeCode, string serviceStartDate)
        {
            if(string.IsNullOrEmpty(memberIdentifier) || string.IsNullOrEmpty(subscriberId) || string.IsNullOrEmpty(coverageTypeCode) || string.IsNullOrEmpty(serviceStartDate))
            return false;
            var member = _context.Members.Include(a=> a.Enrollments).FirstOrDefault(m => m.MemberIdentifier.Equals(memberIdentifier) && m.SubscriberId.Equals(subscriberId));
            if (!member.Enrollments.Any()) return false;
            
            //validate enrollments against coverageTypeCode and start date
            foreach(Enrollment e in member.Enrollments)
            {
                if (e.CoverageType.Equals(coverageTypeCode) && e.CoverageStartDate.Equals(serviceStartDate))
                {
                    return true;
                }
            }
            return false;
        }

        private void BuildInMemoryData()
        {
            if (!_context.Members.Any())
            {
                _context.Members.AddRange
                    (
                      new Member("Satish", "J", "", "Male", "1990-10-02", "Married", "2019-10-18", "2019-10-10", "Medical")
                      {
                          JoiningDate = "2019-11-20",
                          Contacts = new List<Contact>
                     {
                         new Contact {ContactType ="Mobile", Value="9348348317"},
                         new Contact {ContactType ="Work", Value="9348348318"},
                         new Contact {ContactType ="Home", Value="9348348319"}
                     },
                          Addresses = new List<Address>()
                     {
                         new Address() {
                             AddressType="Work",
                             AddressLine1 = "Royal homes layout",
                             City = "Bengaluru",
                             State="KA",
                             Country="India",
                             ZipCode="560068"
                         },
                        new Address() {
                             AddressType="Work",
                             AddressLine1 = "Manyatha Business Park, Hebbal",
                             City = "Bengaluru",
                             State="KA",
                             Country="India",
                             ZipCode="560045"
                         }
                     }
                      },
                      new Member("Soumya", "J", "", "Female", "1995-11-02", "Married", "Mrs.", "2019-10-18", "2019-10-10", "Medical")
                      {
                          JoiningDate = "2019-10-25",
                          Contacts = new List<Contact>
                     {
                         new Contact {ContactType ="Mobile", Value="2311348317"},
                         new Contact {ContactType ="Work", Value="3311348318"},
                         new Contact {ContactType ="Home", Value="4322348319"}
                     },
                          Addresses = new List<Address>()
                     {
                         new Address() {
                             AddressType="Work",
                             AddressLine1 = "AECS layout",
                             City = "Bengaluru",
                             State="KA",
                             Country="India",
                             ZipCode="560068"
                         },
                        new Address() {
                             AddressType="Work",
                             AddressLine1 = "Manyatha Business Park, Hebbal",
                             City = "Bengaluru",
                             State="KA",
                             Country="India",
                             ZipCode="560045"
                         },

                     }
                      }
                    );
                _context.SaveChanges();
            }
        }
    }
}
