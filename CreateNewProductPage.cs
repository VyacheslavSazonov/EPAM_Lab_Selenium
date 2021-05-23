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
    class CreateNewProductPage : AbstractPage
    {
        public CreateNewProductPage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "ProductName")]
        private IWebElement productName;
        [FindsBy(How = How.Id, Using = "CategoryId")]
        private IWebElement categoryId;
        [FindsBy(How = How.Id, Using = "SupplierId")]
        private IWebElement supplierId;
        [FindsBy(How = How.Id, Using = "UnitPrice")]
        private IWebElement unitPrice;
        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        private IWebElement quantityPerUnit;
        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        private IWebElement unitsInStock;
        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        private IWebElement unitsOnOrder;
        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        private IWebElement reorderLevel;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submitSend;

        public AllProducts GoToCreateNewProduct()
        {
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
            submitSend.Click();
            return new AllProducts(driver);
        }
    }
}
