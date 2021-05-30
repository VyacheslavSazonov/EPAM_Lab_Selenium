using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Lab3.dto;

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1Login()
        {
            LoginPage loginpage = new LoginPage(driver);

            HomePage homePage = loginpage.GoToLogin();
            
            Assert.AreEqual("Logout", homePage.logout.Text);
        }

        [Test]
        public void Test2CreateNewProduct()
        {
            LoginPage loginpage = new LoginPage(driver);

            HomePage homePage = loginpage.GoToLogin();

            Thread.Sleep(1000);

            AllProducts allProducts1 = homePage.GoToProducts();

            Thread.Sleep(1000);

            CreateProduct createNewProduct = allProducts1.GoToNewProductPage1();

            AllProducts allProducts = createNewProduct.GoToCreateNewProduct1();
        }

        [Test]
        public void Test3CheckParametrs()
        {
            LoginPage loginpage = new LoginPage(driver);

            HomePage homePage = loginpage.GoToLogin();

            Thread.Sleep(1000);

            AllProducts allProducts1 = homePage.GoToProducts();

            Thread.Sleep(1000);

            ProductPage productPage = allProducts1.GoToProductPage();

            Assert.AreEqual("Carp", productPage.productName.GetAttribute("value"));
            Assert.AreEqual("Seafood", productPage.categoryId.Text);
            Assert.AreEqual("Tokyo Traders", productPage.supplierId.Text);
            Assert.AreEqual("15,0000", productPage.unitPrice.GetAttribute("value"));
            Assert.AreEqual("2 kg box", productPage.quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual("20", productPage.unitsInStock.GetAttribute("value"));
            Assert.AreEqual("12", productPage.unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual("15", productPage.reorderLevel.GetAttribute("value"));
        }


        [Test]
        public void Test4DeleteProduct()
        {
            LoginPage loginpage = new LoginPage(driver);

            HomePage homePage = loginpage.GoToLogin();

            Thread.Sleep(1000);

            AllProducts allProducts1 = homePage.GoToProducts();

            Thread.Sleep(1000);

            AllProducts allProducts = allProducts1.ProductDelete();

            Assert.AreEqual(true, isElementsNotPresent());
        }

        public static bool isElementsNotPresent()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr/td/a[text()='Carp']")).Count != 0;
        }

        [Test]
        public void Test5Logout()
        {
            LoginPage loginpage = new LoginPage(driver);

            HomePage homePage = loginpage.GoToLogin();

            Thread.Sleep(1000);

            LoginPage loginpage1 = homePage.GoToLogOut();

            Assert.AreEqual("Login", loginpage1.resultlogout.Text);
        }
    }
    }