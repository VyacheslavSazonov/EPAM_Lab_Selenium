using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab3.Fabric
{
    class Product
    {
        public String ProductName { get; set; }
        public String CategoryID { get; set; }
        public String SupplierID { get; set; }
        public String UnitPrice { get; set; }
        public String QuantityPerUnit { get; set; }
        public String UnitInStock { get; set; }
        public String UnitOnOrder { get; set; }
        public String ReorderLevel { get; set; }

        public Product()
        {
            ProductName = "Carp";
            CategoryID = "Seafood";
            SupplierID = "Tokyo Traders";
            UnitPrice = "15";
            QuantityPerUnit = "2 kg box";
            UnitInStock = "20";
            UnitOnOrder = "12";
            ReorderLevel = "15";
        }
    }
}
