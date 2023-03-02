using System.Threading;

namespace Photon
{
    [TestClass]
    public class AuthenticationTest : BaseTest
    {

        [TestMethod]
        public void SignInUnSuccessful()
        {
            Driver.Url = "https://www.saucedemo.com/";

            Driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
            Driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Driver.FindElement(By.Id("login-button")).Click();

            var errorElement = Driver.FindElement(By.CssSelector("[data-test=error]"));

            Assert.IsTrue(errorElement.Text.Contains("Sorry, this user has been locked out"));
        }
        
        [TestMethod]
        public void SignInSuccessful()
        {
            Driver.Url = "https://www.saucedemo.com/";

            Driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Driver.FindElement(By.Id("login-button")).Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", Driver.Url);
        }

        [TestMethod]
        public void Logout()
        {
            Driver.Url = "https://www.saucedemo.com/";

            Driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Driver.FindElement(By.Id("login-button")).Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", Driver.Url);

            Driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            Thread.Sleep(1000);

            Driver.FindElement(By.Id("logout_sidebar_link")).Click();

            Assert.AreEqual("https://www.saucedemo.com/", Driver.Url);
        }
    }
}