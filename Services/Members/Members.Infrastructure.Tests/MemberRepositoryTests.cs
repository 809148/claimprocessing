using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Infrastructure.Tests
{
    public class MemberRepositoryTests
    {
        DbContextOptions<MemberDataContext> _options;
        MemberDataContext _context;
        private IMemberRepository _repository;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<MemberDataContext>()
               //.UseInMemoryDatabase(databaseName: "myMembers")
               .UseInMemoryDatabase("myMembers")
               .Options;
            _context = new MemberDataContext(_options);
            _repository = new MemberRepository(_context);
            //Relational - specific methods can only be used when the context is using a relational database provider


        }

        [Test]
        public void GetAllMemberTest()
        {
            var all = _repository.GetAll();
            Assert.IsTrue(all.Any());
        }


        [Test]
        public void GetMemberById()
        {
            var member = _repository.GetAll().FirstOrDefault();
            if (member == null) return;
            var retrievedMemberById = _repository.Get(member.Id);
            Assert.IsNotNull(retrievedMemberById);
            //Assert.AreEqual(member, retrievedMemberById);
            Assert.AreEqual(member.Id, retrievedMemberById.Id);
            Assert.AreEqual(member.FirstName, retrievedMemberById.FirstName);
            Assert.AreEqual(member.LastName, retrievedMemberById.LastName);
            Assert.AreEqual(member.Gender, retrievedMemberById.Gender);
            Assert.AreEqual(member.MaritalStatus, retrievedMemberById.MaritalStatus);
        }

        [Test]
        public void GetMemberWithoutAddressById()
        {
            var member = _repository.GetAll().FirstOrDefault();
            if (member == null) return;
            var retrievedMemberById = _repository.Get(member.Id);
            Assert.IsNotNull(retrievedMemberById);
            Assert.AreEqual(member.Id, retrievedMemberById.Id);
            Assert.AreEqual(member.FirstName, retrievedMemberById.FirstName);
            Assert.AreEqual(member.LastName, retrievedMemberById.LastName);
            Assert.AreEqual(member.Gender, retrievedMemberById.Gender);
            Assert.AreEqual(member.MaritalStatus, retrievedMemberById.MaritalStatus);
            Assert.IsFalse(retrievedMemberById.Addresses.Any());
        }

        [Test]
        public void GetMemberWithAddressById()
        {
            var member = _repository.GetAll().FirstOrDefault();
            if (member == null) return;
            var retrievedMemberById = _repository.Get(member.Id, true);
            Assert.IsNotNull(retrievedMemberById);
            Assert.AreEqual(member.Id, retrievedMemberById.Id);
            Assert.AreEqual(member.FirstName, retrievedMemberById.FirstName);
            Assert.AreEqual(member.LastName, retrievedMemberById.LastName);
            Assert.AreEqual(member.Gender, retrievedMemberById.Gender);
            Assert.AreEqual(member.MaritalStatus, retrievedMemberById.MaritalStatus);
            Assert.True(retrievedMemberById.Addresses.Any());
        }

        [Test]
        public void CanSaveMemberTest()
        {
            var allBeforeAdd = _repository.GetAll().Count;
            var member = BuildMember("Jai", "Jagadi", "Male", "2013-11-02", "Unmarried", "2019-10-18", "2020-10-17", "Medical");
            var returnCode = _repository.Save(member);
            var allAfterAdd = _repository.GetAll().Count;
            Assert.AreEqual(returnCode, 1);
            Assert.IsTrue(allAfterAdd > allBeforeAdd);
        }

        [Test]
        public void CantSaveMemberWithSameFNameLNameAndDobTest()
        {
            var allBeforeAdd = _repository.GetAll().Count;
            var existingMember = _repository.Get(1);
            var member = BuildMember(existingMember.FirstName, existingMember.LastName, "Male", existingMember.DateOfBirth, "Married", "2019-10-18", "2020-10-17", "Medical");
            var returnCode = _repository.Save(member);
            var allAfterAdd = _repository.GetAll().Count;
            Assert.AreEqual(returnCode, -1);
            Assert.IsTrue(allAfterAdd == allBeforeAdd);
        }
        [Test]
        public void CantSaveMemberWithoutAddressTest()
        {
            var allBeforeAdd = _repository.GetAll().Count;
            var member = BuildMember("Jai", "Jagadi","Male", "2013-11-02","Unmarried", "2019-10-18", "2020-10-17", "Medical");
            var returnCode = _repository.Save(member);
            var allAfterAdd = _repository.GetAll().Count;
            //Assert.AreEqual(returnCode, -2);
            Assert.IsTrue(allAfterAdd == allBeforeAdd);
        }

        [Test]
        public void CantSaveMemberWithoutContactsTest()
        {
            var allBeforeAdd = _repository.GetAll().Count;
            var member = BuildMember("Jai", "Jagadi", "Male", "2013-11-02", "Unmarried", "2019-10-18", "2020-10-17", "Medical", true, false);
            var returnCode = _repository.Save(member);
            var allAfterAdd = _repository.GetAll().Count;
            Assert.AreEqual(returnCode, -3);
            Assert.IsTrue(allAfterAdd == allBeforeAdd);
        }

        [Test]
        public void CanUpdateMemberTest()
        {
            var existingMember = _repository.Get(1);
            var newFName = "Raj";
            var newLName = "Jagadi";
            existingMember.FirstName = newFName;
            existingMember.LastName = newLName;
            var returnCode = _repository.Save(existingMember);
            var updatedMember = _repository.Get(1, true);
            Assert.AreEqual(returnCode, 2);
            Assert.AreSame(updatedMember.FirstName, newFName);
            Assert.AreSame(updatedMember.LastName, newLName);
        }

        [Test]
        public void CanDeleteMemberTest()
        {
            var existingMember = _repository.Get(1);
            Assert.IsNotNull(existingMember);
            Assert.IsTrue(existingMember.Id > 0);
            var returnCode = _repository.Delete(1);
            Assert.AreEqual(returnCode, 1);
            existingMember = _repository.Get(1);
            Assert.IsNull(existingMember);
        }
        private Member BuildMember(string fname, string lname,string gender, string dob,string maritalStatus,string doj, string endDate, string coverageTypeCode, bool canAddAddress=true, bool canAddContacts=true)
        {
            var member = new Member(fname, lname, string.Empty, gender, dob, maritalStatus, doj, endDate, coverageTypeCode)
            {
                FirstName = fname,
                LastName = lname,
                Gender = "Male",
                Prefix = "Mr.",
                DateOfBirth = dob,
                MaritalStatus = "Married",

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

            };
            if (!canAddAddress)
            {
                member.Addresses = new List<Address>();
            }
            if (!canAddContacts)
            {
                member.Contacts = new List<Contact>();
            }
            return member;
            
        }
    }
}
