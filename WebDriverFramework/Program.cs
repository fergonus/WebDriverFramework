/* Date: 08-21-2015
 * Youtube Playlist: C# Webdriver Automation Tutorial
 * https://www.youtube.com/watch?v=7JFu8orm0rE&list=PL_noPv5wmuO8ZQmRWOZpCskwjpJZZ964P
 * By: G BoxT
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace WebDriverFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new FirefoxDriver();
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.thetestroom.com/webapp");
            

            // step to interact with the browser
            driver.FindElement(By.Id("contact_link")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Name("name_field")).SendKeys("I will subscribe to this channel");
            driver.FindElement(By.Name("address_field")).SendKeys("Please like this video");

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach(IWebElement link in links)
            {
                if (link.Text.Equals("ABOUT"))
                {
                    link.Click();
                    break;
                }
            }
            //driver.Quit();

        }
    }
}
