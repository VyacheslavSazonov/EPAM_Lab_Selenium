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
        private IWebElement password1;
        [FindsBy(How = How.XPath, Using = "//input [@type='submit']")]
        private IWebElement submitInp;
        [FindsBy(How = How.XPath, Using = "//h2")]
        public IWebElement resultlogout;

        public LoginPage GoToLogin(string name,string password)
        {
            login.SendKeys(name);
            password1.SendKeys(password);
            return new LoginPage(driver);

        }
        public HomePage ClickSend()
        {
            submitInp.Click();
            return new HomePage(driver);
        }
    } 
}
