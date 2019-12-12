using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using NUnit.Framework;
using System;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Tests
{
    public class PayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CannotCreatePayerWithoutAnyRequiredFields()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            }
            catch (ArgumentNullException)
            {
                Assert.IsNull(_payer);
            }
        }

        [Test]
        public void CannotCreateDomainWithoutName()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer(string.Empty, "Royal Homes Layout, Singasandra, Bengaluru", string.Empty, "KA", "560068", "India");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNull(_payer);
                Assert.AreEqual(ex.ParamName, "name is required");
            }
        }

        [Test]
        public void CannotCreateDomainWithoutAddress()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer("ICICI Lombard", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNull(_payer);
                Assert.AreEqual(ex.ParamName, "address is required");
            }
        }

        [Test]
        public void CannotCreateDomainWithoutCity()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer("ICICI Lombard", "Royal Homes Layout, Singasandra, Bengaluru", string.Empty, "KA", "560068", "India");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNull(_payer);
                Assert.AreEqual(ex.ParamName, "city is required");
            }
        }

        [Test]
        public void CannotCreateDomainWithoutState()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer("ICICI Lombard", "Royal Homes Layout, Singasandra", "Bengalurue", string.Empty, "560068", "India");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNull(_payer);
                Assert.AreEqual(ex.ParamName, "state is required");
            }
        }

        [Test]
        public void CannotCreateDomainWithoutZip()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer("ICICI Lombard", "Royal Homes Layout, Singasandru", "Bengaluru", "KA", string.Empty, "India");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNull(_payer);
                Assert.AreEqual(ex.ParamName, "zip is required");
            }
        }

        [Test]
        public void CannotCreateDomainWithoutCountry()
        {
            Payer _payer = null;
            try
            {
                _payer = new Payer("ICICI Lombard", "Royal Homes Layout, Singasandru", "Bengaluru", "KA", "560068", string.Empty);
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNull(_payer);
                Assert.AreEqual(ex.ParamName, "country is required");
            }
        }

        [Test]
        public void CanCreateDomainWithAllRequiredFields()
        {
            Payer _payer = new Payer("ICICI Lombard", "Royal Homes Layout, Singasandru", "Bengaluru", "KA", "560068", "India");
            Assert.IsNotNull(_payer);
                
        }
    }
}