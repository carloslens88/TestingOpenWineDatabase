namespace WineTestingRoche.Steps
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using WineTestingRoche.Driver;
    using WineTestingRoche.PageObjects;

    [Binding]
    public class WineStepsDefinition
    {
        private string urlWinePage = "https://react-bootcamp.github.io/react-wines-101/";
        private IWebDriver driver;
        private WinePageObject winePage;

        public WineStepsDefinition()
        {
            driver = DriverInstance.GetInstance();
            winePage = new WinePageObject(driver);
        }

        [Given(@"open wine website")]
        public void GivenOpenWineWebsite()
        {
            driver.Url = urlWinePage;
        }

        [Then(@"the content must be showed")]
        public void ThenTheContentMustBeShowed()
        {
            Assert.IsTrue(winePage.isPageOpen());
        }

        [When(@"choose region ""([^""]*)""")]
        public void WhenChooseRegion(string region)
        {
            winePage.selectRegion(region);
        }

        [When(@"select wine ""([^""]*)""")]
        public void WhenSelectWine(string wine)
        {
            winePage.selectWine(wine);
        }

        [Then(@"the result should be ""([^""]*)""")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            Assert.True(winePage.wineNameIsDisplayed(expectedResult));
        }

        [Then(@"the wine color should be ""([^""]*)""")]
        public void ThenTheWineColorShouldBe(string color)
        {
            string wineColor = winePage.getWineColor();

            Assert.That(color, Is.EqualTo(wineColor));
        }

        [When(@"press like button")]
        public void WhenPressLikeButton()
        {
            winePage.pressLikeButton();
        }

        [Then(@"must be show unlike button")]
        public void ThenMustBeShowUnlikeButton()
        {
            Assert.True(winePage.unlikeButtonIsDisplayed());
        }

        [When(@"press comment button")]
        public void WhenPressCommentButton()
        {
            winePage.pressCommentButton();
        }

        [When(@"add some comments ""([^""]*)""")]
        public void WhenAddSomeComments(string comment)
        {
            winePage.sendComment(comment);
        }

        [Then(@"comment ""([^""]*)"" must be show on description area")]
        public void ThenCommentMustBeShowOnDescriptionArea(string comment)
        {
            Assert.True(winePage.commentPresentInDescriptionArea(comment));
        }


        [AfterScenario]
        public void tearDownDriver()
        {
            DriverInstance.CloseBrowser();
        }
    }
}