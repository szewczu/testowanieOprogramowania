using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using Xunit;

namespace SeleniumApplication.Shared
{
    static class Helpers
    {
        public static ChromeDriver RunPage(string pageUrl)
        {
            string url = GetPage(pageUrl);
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            return driver;

        }

        public static ChromeDriver RunPageWithOpenedBrowser(string pageUrl)
        {
            
            string url = GetPage(pageUrl);
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        private static string GetPage(string page)
        {
            return GetValueFromSettings("..Base") + page;
        }

        public static string GetValueFromSettings(string jsonPath)
        {
            string jsonSettingsFile = File.ReadAllText("Settings.json");
            JObject settingsObject = JObject.Parse(jsonSettingsFile);
            string value = (string)settingsObject.SelectToken(jsonPath);

            return value;
        }

        public static IWebElement GetWebElement(ChromeDriver driver, string xPath)
        {
            IWebElement element = driver.FindElementByXPath(xPath);
            return element;
        }

        public static string GetValue(IWebElement element)
        {
            string value = element.GetAttribute("value");
            return value;
        }

        public static void WriteText(IWebElement textBox, string text)
        {
            textBox.SendKeys(text);
        }
        public static string GetValueFromDictionary(Dictionary<string, string> dict, Enum key)
        {
            return dict[key.ToString()];
        }

        public static void AssertTrue(ChromeDriver driver, bool condition, string message)
        {
            driver.Quit();
            Assert.True(condition, message);
        }

        public static void AssertFalse(ChromeDriver driver, bool condition, string message)
        {
            driver.Quit();
            Assert.False(condition, message);
        }

    }
}
