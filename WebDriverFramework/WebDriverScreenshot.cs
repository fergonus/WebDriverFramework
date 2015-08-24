/* Date: 08-21-2015
 * C# WebDriver Automation Tutorial 07 Taking Screenshots-3w5hbt4YdFs
 * Taking Screenshot
 * Screenshot is stored at:
 * C:\Users\errol\Documents\Visual Studio 2015\Projects\WebDriverFramework\WebDriverFramework\bin\Debug\ContactTestPage.jpg
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace WebDriverFramework
{
    [TestFixture]
    class WebDriverScreenshot
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
        public void checkContactPageTitle()
        {
            driver.FindElement(By.Id("contact_link")).Click();

            System.Threading.Thread.Sleep(1000);

            Assert.True(driver.Title.Contains("Contact"));

            takeScreenshot("ContactTestPage");

        }

        
        public void takeScreenshot(string fileName)
        {
            ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            screenshot.SaveAsFile(fileName + ".jpg", ImageFormat.Jpeg);
            // Filename: 
            // C:\Users\errol\Documents\Visual Studio 2015\Projects\WebDriverFramework\WebDriverFramework\bin\Debug\ContactTestPage.jpg
        }


    }
}
