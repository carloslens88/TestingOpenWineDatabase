namespace WineTestingRoche.PageObjects
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    public class WinePageObject
    {
        private IWebDriver driver;

        public WinePageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Regions')]")]
        private IWebElement textRegions;

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Wines')]")]
        private IWebElement textWines;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Like')]")]
        private IWebElement likeButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Comment')]")]
        private IWebElement commentButton;

        public bool isPageOpen() 
        {
            return textRegions.Displayed && textWines.Displayed;
        }

        public void selectRegion(string region)
        {            
            driver.FindElement(By.XPath("//a[contains(text(),'" + region + "')]")).Click();
        }

        public void selectWine(string wine)
        {
            driver.FindElement(By.XPath("//a[contains(text(),'" + wine + "')]")).Click();
        }

        public bool wineNameIsDisplayed(string wineName)
        {
            return driver.FindElement(By.XPath("//h3[contains(text(),'" + wineName + "')]")).Displayed;
        }

        public string getWineColor()
        {
            return driver.FindElement(By.XPath("//div[@class='card-content']"))
                .FindElements(By.TagName("p"))[2].Text.Replace("Color: ", string.Empty);

        }

        public void pressLikeButton()
        {
            likeButton.Click();
        }

        public bool unlikeButtonIsDisplayed()
        {
            return driver.FindElement(By.XPath("//span[contains(text(),'Unlike')]")).Displayed;
        }

        public void pressCommentButton() 
        {
            commentButton.Click();

        }

        public void sendComment(string comment)
        {
            driver.FindElement(By.Id("inputComment")).SendKeys(comment);
            driver.FindElement(By.XPath("//a[contains(text(),'Comment')]")).Click();
        }

        public bool commentPresentInDescriptionArea(string comment)
        {
            return driver.FindElement(By.XPath("//p[contains(text(),'" + comment + "')]")).Displayed;
        }
    }
}