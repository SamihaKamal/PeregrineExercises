
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppsTest
{
    [TestClass]
    public class UnitTest
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void test_create_product_form()
        {
            driver.Url = "http://localhost:58788/";
            driver.Navigate().GoToUrl("http://localhost:58788/Product/Create");
            driver.Manage().Window.Maximize();
            IWebElement FeedCreate = driver.FindElement(By.XPath("/html/body/div[1]/h2"));
            string text = FeedCreate.Text;
            NUnit.Framework.Assert.That(true, "Create", text);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void testCreate()
        {
            driver.Url = "http://localhost:58788/";
            driver.Navigate().GoToUrl("http://localhost:58788/Product/Create");
            driver.Manage().Window.Maximize();
            IWebElement productNameBox = driver.FindElement(By.XPath("/html/body/div[1]/form/div/div[1]/div/input"));
            productNameBox.Click();
            productNameBox.SendKeys("Orange");
            System.Threading.Thread.Sleep(2000);
            IWebElement priceNameBox = driver.FindElement(By.XPath("/html/body/div[1]/form/div/div[2]/div/input"));
            priceNameBox.Click();
            priceNameBox.SendKeys("2.0");
            System.Threading.Thread.Sleep(2000);
            IWebElement desNameBox = driver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/div/input"));
            desNameBox.Click();
            desNameBox.SendKeys("an Orange");
            System.Threading.Thread.Sleep(2000);

            IWebElement submit = driver.FindElement(By.XPath("/html/body/div[1]/form/div/div[4]/div/input"));
            submit.Click();

            IWebElement index = driver.FindElement(By.XPath("/html/body/div[1]/h2"));
            string text = index.Text;
            NUnit.Framework.Assert.That(true, "Index View", text);
            System.Threading.Thread.Sleep(5000);
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
