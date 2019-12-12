using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using NUnit.Framework;
using System;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Tests
{
    public class ProviderTests
    {

        [Test]
        public void CantCreateProviderWithoutAnyRequiredFields()
        {
            Provider provider = null;
            try
            {
                provider = new Provider(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,343434, string.Empty, null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(provider);
        }

        [Test]
        public void CannotCreateProviderWithoutAddress()
        {
            Provider provider = null;
            try
            {
                provider = new Provider("LIC", string.Empty, "#113, MG Road", "Bengaluru", "KA", 343434, "India", "Individual");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(provider);
        }

        [Test]
        public void CannotCreateProviderWithoutCity()
        {
            Provider provider = null;
            try
            {
                provider = new Provider("LIC", "#113, MG Road", String.Empty,"ka", "India", 343434, "2010-10-12", "Individal");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(provider);
        }


        [Test]
        public void CannotCreateProviderWithoutState()
        {
            Provider provider = null;
            try
            {
                provider = new Provider("LIC", "#113, MG Road", "Bengaluru",string.Empty,"India", 343434, "2010-10-12", "Individual");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(provider);
        }

        [Test]
        public void CannotCreateProviderWithoutRegisteredDate()
        {
            Provider provider = null;
            try
            {
                provider = new Provider("LIC", "#113, MG Road", "Bengaluru", "KA", "india", 343434, string.Empty, "Individual");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.");
            }
            Assert.IsNull(provider);
        }

        [Test]
        public void CannotCreateProviderWithoutProviderType()
        {
            Provider provider = null;
            try
            {
                provider = new Provider("LIC", "113, MGRoad", "#113, MG Road", "Bengaluru","india", 343434, "2011-11-03", null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "provider type cannot be null.\r\nParameter name: provider type");
            }
            Assert.IsNull(provider);
        }

        
    }
}