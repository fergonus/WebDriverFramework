/* Date: 08-21-2015
 * C# WebDriver Automation Tutorial 06 Alerts and Windows-w3RrQbaCkbA
 * Using NUnit Framework
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    [TestFixture]
    class WebDriverTestSample
    {
        
        IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.thetestroom.com/webapp");
            // Console.WriteLine("Setup");
        }
        
        [TearDown]
        public void tearDown()
        {
            driver.Close();
            // Console.WriteLine("Teardown");
        }

        [Test]
        public void shouldOpenTermsWindowAndCloseIt()
        {
            String parentWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.Id("footer_term")).Click();

            System.Threading.Thread.Sleep(1000);
            foreach (String window in driver.WindowHandles)
            {
                System.Threading.Thread.Sleep(1000);
                driver.SwitchTo().Window(window); // switch to the term window
            }

            Assert.True(driver.Url.Contains("terms")); // verify that the term window is opened

            driver.Close(); // close the term window
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Window(parentWindow);  // switch back to the parent window
            System.Threading.Thread.Sleep(1000);
            Assert.True(driver.Title.Contains("Home"));  // verify that we are back into the parent window

        }

        [Test]
        public void shouldBeAbleToCloseAlertPopup()
        {
            driver.FindElement(By.Id("contact_link")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("submit_message")).Click(); // this will create an alert popup

            System.Threading.Thread.Sleep(1000);
            IAlert popup = driver.SwitchTo().Alert(); // switch control to the alert
            Assert.True(popup.Text.Contains("empty"));  // verify that the alert window is opened

            popup.Accept();  // click the accept button and closes the alert window
            System.Threading.Thread.Sleep(1000);
            Assert.True(driver.Title.Contains("Contact"));  // verify that we back in the main window

        }
        

    }
}
