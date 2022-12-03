using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("//img[@alt='Tricentis Demo Web Shop']")).Click();
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("mateo.tokic1@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Mateo2509");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.LinkText("mateo.tokic1@gmail.com")).Click();
            driver.FindElement(By.LinkText("Addresses")).Click();
            driver.FindElement(By.XPath("//input[@value='Add new']")).Click();
            driver.FindElement(By.Id("Address_FirstName")).Click();
            driver.FindElement(By.Id("Address_FirstName")).Clear();
            driver.FindElement(By.Id("Address_FirstName")).SendKeys("Mateo");
            driver.FindElement(By.Id("Address_Email")).Click();
            driver.FindElement(By.Id("Address_Email")).Click();
            driver.FindElement(By.Id("Address_Email")).Clear();
            driver.FindElement(By.Id("Address_Email")).SendKeys("mateo.tokic1@gmail.com");
            driver.FindElement(By.Id("Address_LastName")).Click();
            driver.FindElement(By.Id("Address_LastName")).Clear();
            driver.FindElement(By.Id("Address_LastName")).SendKeys("Tokić");
            driver.FindElement(By.Id("Address_CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("Address_CountryId"))).SelectByText("Croatia");
            driver.FindElement(By.XPath("//option[@value='24']")).Click();
            driver.FindElement(By.Id("Address_City")).Click();
            driver.FindElement(By.Id("Address_City")).Click();
            driver.FindElement(By.Id("Address_City")).Clear();
            driver.FindElement(By.Id("Address_City")).SendKeys("Osijek");
            driver.FindElement(By.Id("Address_Address1")).Click();
            driver.FindElement(By.Id("Address_Address1")).Clear();
            driver.FindElement(By.Id("Address_Address1")).SendKeys("Sjenjak 67");
            driver.FindElement(By.Id("Address_ZipPostalCode")).Click();
            driver.FindElement(By.Id("Address_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("Address_ZipPostalCode")).SendKeys("31000");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='*'])[7]/following::label[1]")).Click();
            driver.FindElement(By.Id("Address_PhoneNumber")).Clear();
            driver.FindElement(By.Id("Address_PhoneNumber")).SendKeys("0995619098");
            driver.FindElement(By.XPath("//input[@value='Save']")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
