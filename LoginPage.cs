using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab3
{
    class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement login;
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input [@type='submit']")]
        private IWebElement submitInp;
        [FindsBy(How = How.XPath, Using = "//h2")]
        public IWebElement resultlogout;

        public HomePage GoToLogin()
        {
            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();
            return new HomePage(driver);
        }
    } 
}
