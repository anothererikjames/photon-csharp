using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
#if SAUCE
    [assembly: Parallelize(Workers = 15, Scope = ExecutionScope.MethodLevel)]
#endif

namespace Photon
{
    public class BaseTest
    {
        protected IWebDriver? Driver;
        public TestContext? TestContext { get; set; }

        [TestInitialize]
        public void CreateDriver()
        {
#if SAUCE
            SauceDriver();
#else
            LocalDriver();
#endif
        }

        public void LocalDriver()
        {
            Driver = new ChromeDriver();
        }

        public void SauceDriver()
        {
            var browserOptions = new ChromeOptions
            {
                PlatformName = "Windows 10",
                BrowserVersion = "latest"
            };

            var sauceOptions = new Dictionary<string, object?>
            {
                { "name", TestContext!.TestName },
                { "build", Constants.BuildId },
                { "username", Environment.GetEnvironmentVariable("SAUCE_USERNAME") },
                { "accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY") }
            };

            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
            var sauceUrl = new Uri("https://ondemand.us-west-1.saucelabs.com/wd/hub");

            Driver = new RemoteWebDriver(sauceUrl, browserOptions);
        }

        [TestCleanup]
        public void Teardown()
        {
            var isPassed = TestContext!.CurrentTestOutcome == UnitTestOutcome.Passed;
#if SAUCE
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor)Driver!).ExecuteScript(script);
#else
            Console. WriteLine("Test Result: " + isPassed);
#endif
            Driver?.Quit();
        }

        protected void Login()
        {
            Driver!.Url = "https://www.saucedemo.com/";
            Driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Driver.FindElement(By.Id("login-button")).Click();
        }

        protected void AddToCart()
        {
            Driver!.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();
            Driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            Driver.FindElement(By.Id("checkout")).Click();
        }
    }
}