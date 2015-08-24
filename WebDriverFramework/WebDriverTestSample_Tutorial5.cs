/* Date: 08-21-2015
 * C# WebDriver Automation Tutorial 05 NUnit 2-YsR_h8U8MVg
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
        [Test] // [Test, Ignore] = Ignoring a test
        public void sampleTest()
        {
            int a = 10;
            int b = 10;

            Assert.AreEqual(a, b);
            // Console.WriteLine("Test case 01");
        }

        IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
            // Console.WriteLine("Setup");
        }
        

        [Test]
        public void shouldCheckApplicationUrl()
        {
            
            driver.Navigate().GoToUrl("http://www.thetestroom.com/webapp");

            Assert.True(driver.Url.Contains("webapp"));
            // Console.WriteLine("Test case 02");


        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
            // Console.WriteLine("Teardown");
        }
        

    }
}
