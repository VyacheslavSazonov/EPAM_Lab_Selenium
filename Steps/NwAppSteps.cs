using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Lab3.Fabric;
using Lab3.PageObjects;
using Lab3.dto;
using NUnit.Framework;

namespace BDD.Steps
{
    [Binding]
    public class NwAppSteps
    {
        private static IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.Navigate().GoToUrl(url);
        }

        [When(@"I login with name ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithNameAndPassword(string name, string password)
        {
            new LoginPage(driver).GoToLogin(name, password);
        }

        [When(@"I click on button send")]
        public void WhenIClickOnButtonSend()
        {
            new LoginPage(driver).ClickSend();
        }

        [When(@"I click on button All Products")]
        public void WhenIClickOnButtonAllProducts()
        {
            new HomePage(driver).GoToProducts();
        }

        [When(@"I click on button Create New")]
        public void WhenIClickOnButtonCreateNew()
        {
            new AllProducts(driver).GoToNewProductPage1();
        }

        [When(@"I fill field for create new product")]
        public void WhenIFillFieldForCreateNewProduct()
        {
            new CreateProduct(driver).GoToCreateNewProduct1();
        }

        [When(@"I click on button send product")]
        public void WhenIClickOnButtonSendProduct()
        {
            new CreateProduct(driver).GoToCreateNewProduct2();
        }

        [When(@"I click on new test product")]
        public void WhenIClickOnNewTestProduct()
        {
            new AllProducts(driver).GoToProductPage();
        }

        [Then(@"all field should be filled correct")]
        public void ThenAllFieldShouldBeFilledCorrect()
        {
            ProductPage productPage = new ProductPage(driver);
            Product product = new Product();
            Assert.AreEqual("Carp", productPage.productName.GetAttribute("value"));
            Assert.AreEqual("Seafood", productPage.categoryId.Text);
            Assert.AreEqual("Tokyo Traders", productPage.supplierId.Text);
            Assert.AreEqual("15,0000", productPage.unitPrice.GetAttribute("value"));
            Assert.AreEqual("2 kg box", productPage.quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual("20", productPage.unitsInStock.GetAttribute("value"));
            Assert.AreEqual("12", productPage.unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual("15", productPage.reorderLevel.GetAttribute("value"));
            driver.Quit();
        }

        [When(@"I click on button Remove test product")]
        public void WhenIClickOnButtonRemoveTestProduct()
        {
            new AllProducts(driver).ProductDelete();
        }

        [Then(@"test product should be remove")]
        public void ThenTestProductShouldBeRemove()
        {
            Assert.AreEqual(true, isElementsNotPresent());
        }

        public static bool isElementsNotPresent()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr/td/a[text()='Carp']")).Count != 0;
        }
    }
}
