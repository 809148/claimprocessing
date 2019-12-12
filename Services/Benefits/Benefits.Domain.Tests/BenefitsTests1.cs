using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Tests
{
    public class BenefitsTests
    {

        [Test]
        public void CannotCreateBenefitWithoutAnyRequiredFields()
        {
            Benefit benefit = null;
            try
            {
                benefit = new Benefit(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(member);
        }


        //[Test]
        //public void CanCreateMemberwithRequiredFields()
        //{
        //    Member member = null;
        //    try
        //    {
        //        member = BuildMember();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    Assert.IsNotNull(member);
        //}

        //private Member BuildMember()
        //{

        //    return new Member("Avinash", "K", "", "Male", "1990-10-02", "Unmarried")
        //    {
        //        Contacts = new List<Contact>
        //             {
        //                 new Contact {ContactType ="Mobile", Value="9348348317"},
        //                 new Contact {ContactType ="Work", Value="9348348318"},
        //                 new Contact {ContactType ="Home", Value="9348348319"}
        //             },
        //        Addresses = new List<Address>()
        //             {
        //                 new Address() {
        //                     AddressType="Work",
        //                     AddressLine1 = "Royal homes layout",
        //                     City = "Bengaluru",
        //                     State="KA",
        //                     Country="India",
        //                     ZipCode="560068"
        //                 }
        //        }
        //    };
        //}
    }
}
