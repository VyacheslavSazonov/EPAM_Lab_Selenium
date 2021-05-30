using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab3
{
    [TestFixture]
    public class Tests
    {
        public static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1Login()
        {
            IWebElement login = driver.FindElement(By.Id("Name"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement submitInp = driver.FindElement(By.XPath("//input [@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();

            IWebElement result = driver.FindElement(By.XPath("//a [@href='/Account/Logout']"));

            Assert.AreEqual("Logout", result.Text);
        }


        [Test]
        public void Test2CreateNewProduct()
        {
            IWebElement login = driver.FindElement(By.Id("Name"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement submitInp = driver.FindElement(By.XPath("//input [@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();

            Thread.Sleep(1000);

            IWebElement allProducts = driver.FindElement(By.XPath("//div/a[@href='/Product']"));
            allProducts.Click();

            Thread.Sleep(1000);

            IWebElement createNew = driver.FindElement(By.XPath("//div/a[@class='btn btn-default']"));
            createNew.Click();

            Thread.Sleep(1000);

            IWebElement productName = driver.FindElement(By.Id("ProductName"));
            IWebElement categoryId = driver.FindElement(By.Id("CategoryId"));
            IWebElement supplierId = driver.FindElement(By.Id("SupplierId"));
            IWebElement unitPrice = driver.FindElement(By.Id("UnitPrice"));
            IWebElement quantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            IWebElement unitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            IWebElement unitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            IWebElement reorderLevel = driver.FindElement(By.Id("ReorderLevel"));

            SelectElement clickCategory = new SelectElement(categoryId);
            SelectElement clickSupplier = new SelectElement(supplierId);

            productName.SendKeys("Carp");
            clickCategory.SelectByText("Seafood");
            clickSupplier.SelectByText("Tokyo Traders");
            unitPrice.SendKeys("15");
            quantityPerUnit.SendKeys("2 kg box");
            unitsInStock.SendKeys("20");
            unitsOnOrder.SendKeys("12");
            reorderLevel.SendKeys("15");

            IWebElement submitSend = driver.FindElement(By.XPath("//input[@type='submit']"));
            submitSend.Click();

            IWebElement resultTest = driver.FindElement(By.XPath("//table/tbody/tr/td/a[text()='Carp']"));
            Assert.AreEqual("Carp", resultTest.Text);
        }

        [Test]
        public void Test3CheckParametrs()
        {
            IWebElement login = driver.FindElement(By.Id("Name"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement submitInp = driver.FindElement(By.XPath("//input [@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();

            Thread.Sleep(1000);

            IWebElement allProducts = driver.FindElement(By.XPath("//div/a[@href='/Product']"));
            allProducts.Click();

            Thread.Sleep(1000);

            IWebElement editProduct = driver.FindElement(By.XPath("//td/a[text()='Carp']"));
            editProduct.Click();

            IWebElement productName = driver.FindElement(By.Id("ProductName"));
            IWebElement categoryId = driver.FindElement(By.XPath("//select[@id='CategoryId']//option[@selected='selected']"));
            IWebElement supplierId = driver.FindElement(By.XPath("//select[@id='SupplierId']//option[@selected='selected']"));
            IWebElement unitPrice = driver.FindElement(By.Id("UnitPrice"));
            IWebElement quantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            IWebElement unitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            IWebElement unitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            IWebElement reorderLevel = driver.FindElement(By.Id("ReorderLevel"));

            Assert.AreEqual("Carp", productName.GetAttribute("value"));
            Assert.AreEqual("Seafood", categoryId.Text);
            Assert.AreEqual("Tokyo Traders", supplierId.Text);
            Assert.AreEqual("15,0000", unitPrice.GetAttribute("value"));
            Assert.AreEqual("2 kg box", quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual("20", unitsInStock.GetAttribute("value"));
            Assert.AreEqual("12", unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual("15", reorderLevel.GetAttribute("value"));


            IWebElement backProducts = driver.FindElement(By.XPath("//a[text() = 'Products']"));
            backProducts.Click();

        }


        [Test]
        public void Test4DeleteProduct()
        {
            IWebElement login = driver.FindElement(By.Id("Name"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement submitInp = driver.FindElement(By.XPath("//input [@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();

            Thread.Sleep(1000);

            IWebElement allProducts = driver.FindElement(By.XPath("//div/a[@href='/Product']"));
            allProducts.Click();

            Thread.Sleep(1000);

            IWebElement removeProduct = driver.FindElement(By.XPath("//td[a[text()='Carp']] / following-sibling::td [a[text()='Remove']]"));
            removeProduct.Click();

            driver.SwitchTo().Alert().Accept();

            Assert.AreEqual(true, isElementsNotPresent());
        }


        public static bool isElementsNotPresent()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr/td/a[text()='Carp']")).Count != 0;
        }

        [Test]
        public void Test5Logout()
        {
            IWebElement login = driver.FindElement(By.Id("Name"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement submitInp = driver.FindElement(By.XPath("//input [@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();

            Thread.Sleep(1000);

            IWebElement allProducts = driver.FindElement(By.XPath("//div/a[@href='/Product']"));
            allProducts.Click();

            Thread.Sleep(1000);

            IWebElement logout = driver.FindElement(By.XPath("//a[@href='/Account/Logout']"));
            logout.Click();
            IWebElement resultTest5 = driver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("Login", resultTest5.Text);
        }


    }
}