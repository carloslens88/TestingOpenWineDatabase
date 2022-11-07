namespace WineTestingRoche.Driver
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;

    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = CreateDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Close();
            driver = null;
        }

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);

            return driver;
        }
    }
}