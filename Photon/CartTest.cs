using System.Collections.ObjectModel;

namespace Photon
{
    [TestClass]
    public class CartTest : BaseTest
    {

        [TestMethod]
        public void AddFromProductPage()
        {
            Login();
            Driver.FindElement(By.Id("item_1_title_link")).Click();
            Driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

            var badge = Driver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.AreEqual("1", badge.Text);
        }

        [TestMethod]
        public void RemoveFromProductPage()
        {
            Login();
            Driver.FindElement(By.Id("item_1_title_link")).Click();
            Driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

            Driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt")).Click();

            ReadOnlyCollection<IWebElement> items = Driver.FindElements(By.ClassName("shopping_cart_badge"));
            Assert.AreEqual(0, items.Count);
        }

        [TestMethod]
        public void AddFromInventoryPage()
        {
            Login();

            Driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

            var badge = Driver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.AreEqual("1", badge.Text);
        }

        [TestMethod]
        public void RemoveFromInventoryPage()
        {
            Login();
            Driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

            Driver.FindElement(By.Id("remove-sauce-labs-bike-light")).Click();

            ReadOnlyCollection<IWebElement> items = Driver.FindElements(By.ClassName("shopping_cart_badge"));
            Assert.AreEqual(0, items.Count);
        }

        [TestMethod]
        public void RemoveFromCartPage()
        {
            Login();
            Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            Driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            Driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();

            ReadOnlyCollection<IWebElement> items = Driver.FindElements(By.ClassName("shopping_cart_badge"));
            Assert.AreEqual(0, items.Count);
        }
    }
}