namespace WineTestingRoche.TestCases
{
    using OpenQA.Selenium;
    using WineTestingRoche.Driver;
    using WineTestingRoche.PageObjects;

    public class WineTestSuite
    {

        private string urlWinePage = "https://react-bootcamp.github.io/react-wines-101/";
        private IWebDriver driver;
        private WinePageObject winePage;

        [SetUp]
        public void Init()
        {
            driver = DriverInstance.GetInstance();
            winePage = new WinePageObject(driver);

            driver.Url = urlWinePage;
        }

        /*
        [Test]
        public void testWinePageOpens() 
        {
            Assert.IsTrue(winePage.isPageOpen());
        }
        */


        [TearDown]
        public void Cleanup()
        {
            DriverInstance.CloseBrowser();
        }
    }
}
