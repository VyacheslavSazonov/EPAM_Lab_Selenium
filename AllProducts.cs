using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Lab3.dto;

namespace Lab3
{
    class AllProducts : AbstractPage
    {
        public AllProducts(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div/a[@class='btn btn-default']")]
        private IWebElement createNewProduct;
        [FindsBy(How = How.XPath, Using = "//td/a[text()='Carp']")]
        private IWebElement productParametrPage;
        [FindsBy(How = How.XPath, Using = "//td[a[text()='Carp']] / following-sibling::td [a[text()='Remove']]")]
        private IWebElement productRemove;

        public CreateProduct GoToNewProductPage1()
        {
            createNewProduct.Click();
            return new CreateProduct(driver);
        }
        public ProductPage GoToProductPage()
        {
            productParametrPage.Click();
            return new ProductPage(driver);
        }
        public AllProducts ProductDelete()
        {
            productRemove.Click();
            driver.SwitchTo().Alert().Accept();
            return new AllProducts(driver);
        }

    }
}
