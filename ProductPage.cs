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
    class ProductPage : AbstractPage
    {
        public ProductPage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "ProductName")]
        public IWebElement productName;
        [FindsBy(How = How.XPath, Using = "//select[@id='CategoryId']//option[@selected='selected']")]
        public IWebElement categoryId;
        [FindsBy(How = How.XPath, Using = "//select[@id='SupplierId']//option[@selected='selected']")]
        public IWebElement supplierId;
        [FindsBy(How = How.Id, Using = "UnitPrice")]
        public IWebElement unitPrice;
        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        public IWebElement quantityPerUnit;
        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        public IWebElement unitsInStock;
        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        public IWebElement unitsOnOrder;
        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        public IWebElement reorderLevel;
    }
}
