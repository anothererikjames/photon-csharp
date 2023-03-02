namespace Photon
{
    [TestClass]
    public class NavigationTest : BaseTest
    {

        [TestMethod]
        public void CancelFromCartPage()
        {
            Login();
            Driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();
            Driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            
            Driver.FindElement(By.Id("continue-shopping")).Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", Driver.Url);
        }

        [TestMethod]
        public void CancelFromInfoPage()
        {
            Login();
            AddToCart();
            
            Driver.FindElement(By.Id("cancel")).Click();

            Assert.AreEqual("https://www.saucedemo.com/cart.html", Driver.Url);
        }

        [TestMethod]
        public void CancelFromCheckoutPage()
        {
            Login();
            AddToCart();
            Driver.FindElement(By.Id("first-name")).SendKeys("Luke");
            Driver.FindElement(By.Id("last-name")).SendKeys("Perry");
            Driver.FindElement(By.Id("postal-code")).SendKeys("90210");
            Driver.FindElement(By.Id("continue")).Click();

            Driver.FindElement(By.Id("cancel")).Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", Driver.Url);
        }
        
        [TestMethod]
        public void StartCheckout()
        {
            Login();
            Driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();
            Driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            Driver.FindElement(By.Id("checkout")).Click();

            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", Driver.Url);
        }
    }
}