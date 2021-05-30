using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Lab3.Fabric;

namespace Lab3.dto
{
    class CreateProduct : AbstractPage
    {
        public CreateProduct(IWebDriver driver)
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

        public AllProducts GoToCreateNewProduct1()
        {
            Product product = new Product();

            SelectElement clickCategory = new SelectElement(categoryId);
            SelectElement clickSupplier = new SelectElement(supplierId);
            productName.SendKeys(product.ProductName);
            clickCategory.SelectByText(product.CategoryID);
            clickSupplier.SelectByText(product.SupplierID);
            unitPrice.SendKeys(product.UnitPrice);
            quantityPerUnit.SendKeys(product.QuantityPerUnit);
            unitsInStock.SendKeys(product.UnitInStock);
            unitsOnOrder.SendKeys(product.UnitOnOrder);
            reorderLevel.SendKeys(product.ReorderLevel);
            submitSend.Click();
            return new AllProducts(driver);
        }
    }
}

