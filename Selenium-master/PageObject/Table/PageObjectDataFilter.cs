using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Table
{
    class PageObjectDataFilter
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Table.TableFilter");

        public const string XPathButtonGreen = "/html/body/div[2]/div/div[2]/section/div/div/div[2]/div[1]/div/button[1]";
        public const string XPathButtonOrange = "/html/body/div[2]/div/div[2]/section/div/div/div[2]/div[1]/div/button[2]"; 
        public const string XPathButtonRed = "/html/body/div[2]/div/div[2]/section/div/div/div[2]/div[1]/div/button[3]"; 
        public const string XPathButtonAll = "/html/body/div[2]/div/div[2]/section/div/div/div[2]/div[1]/div/button[4]";

        public const string XPathTable = "/html/body/div[2]/div/div[2]/section/div/div/div[2]/div[2]/table";

        public IWebElement GetButtonGreen(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonGreen);
        public IWebElement GetButtonOrange(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonOrange);
        public IWebElement GetButtonRed(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonRed);
        public IWebElement GetButtonAll(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonAll);
        public IWebElement GetTable(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathTable);

    }
}
