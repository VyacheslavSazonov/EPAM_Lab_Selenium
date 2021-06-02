using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab3.PageObjects
{
    class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/a[@href='/Product']")]
        public IWebElement allProducts;
        [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Logout']")]
        public IWebElement logout;

        public AllProducts GoToProducts()
        {
            allProducts.Click();
            return new AllProducts(driver);
        }
        public LoginPage GoToLogOut()
        {
            logout.Click();
            return new LoginPage(driver);
        }

    }
}
