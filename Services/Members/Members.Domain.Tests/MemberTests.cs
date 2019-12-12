using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Tests
{
    public class MemberTests
    {

        [Test]
        public void CannotCreateMemberWithoutAnyRequiredFields()
        {
            Member member = null;
            try
            {
                member = new Member(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(member);
        }


        [Test]
        public void CanCreateMemberwithRequiredFields()
        {
            Member member = null;
            try
            {
                member = BuildMember();
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);//ignore it
            }
            Assert.IsNotNull(member);
        }

        private Member BuildMember()
        {

            return new Member("Avinash", "K", "", "Male", "1990-10-02", "Unmarried", "2018-10-11", "2019-10-10", "Medical")
            {
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
                         }
                }
            };
        }
    }
}