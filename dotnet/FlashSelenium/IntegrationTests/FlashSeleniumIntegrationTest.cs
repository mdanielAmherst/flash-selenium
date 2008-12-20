using NUnit.Framework;
using Selenium;

namespace IntegrationTests
{
    [TestFixture]
    public class FlashSeleniumIntegrationTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            ISelenium selenium = new DefaultSelenium("localhost", 4444, "*chrome", URL);
            flashSelenium = new FlashSelenium.FlashSelenium(selenium, flashObjectId);
        }

        [TearDown]
        public void TearDown()
        {
            flashSelenium.Stop();
        }

        #endregion

        private FlashSelenium.FlashSelenium flashSelenium;
        private readonly string flashObjectId = "clickcolors";
        private readonly string URL = "http://localhost/colors.html";


        [Test]
        public void ShouldTestFlashSeleniumInFirefox3()
        {
            flashSelenium.Start();
            flashSelenium.Open(URL);
            flashSelenium.Call("click");
            Assert.AreEqual("BLUE", flashSelenium.Call("getColor"));
        }
    }
}