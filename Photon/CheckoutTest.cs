namespace Photon
{
    [TestClass]
    public class CheckoutTest : BaseTest
    {

        [TestMethod]
        public void BadInfo()
        {
            Login();
            AddToCart();

            Driver.FindElement(By.Id("continue")).Click();

            var name = Driver.FindElement(By.Id("first-name"));

            Assert.IsTrue(name.GetAttribute("class").Contains("error"));
        }

        [TestMethod]
        public void GoodInfo()
        {
            Login();
            AddToCart();
            Driver.FindElement(By.Id("first-name")).SendKeys("Luke");
            Driver.FindElement(By.Id("last-name")).SendKeys("Perry");
            Driver.FindElement(By.Id("postal-code")).SendKeys("90210");

            Driver.FindElement(By.Id("continue")).Click();

            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", Driver.Url);
        }

        [TestMethod]
        public void CompleteCheckout()
        {
            Login();
            AddToCart();
            Driver.FindElement(By.Id("first-name")).SendKeys("Luke");
            Driver.FindElement(By.Id("last-name")).SendKeys("Perry");
            Driver.FindElement(By.Id("postal-code")).SendKeys("90210");
            Driver.FindElement(By.Id("continue")).Click();

            Driver.FindElement(By.Id("finish")).Click();

            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", Driver.Url);
            var complete = Driver.FindElement(By.ClassName("complete-text"));

            Assert.IsTrue(complete.Displayed);
        }
    }
}