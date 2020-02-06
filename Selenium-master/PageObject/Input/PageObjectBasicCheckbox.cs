using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Input
{
    public class PageObjectBasicCheckbox
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.CheckBox");

        public const string XPathCheckBoxAge = "//*[@id='isAgeSelected']";
        public const string XPathMessageSelectedAge = "//*[@id='txtAge']";
        public const string XPathCheckBox1 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label/input";
        public const string XPathCheckBox2 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label/input";
        public const string XPathCheckBox3 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[3]/label/input";
        public const string XPathCheckBox4 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[4]/label/input";
        public const string XPathButtonCheck = "//*[@id='check1']";


        public IWebElement GetCheckBoxAge(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCheckBoxAge);

        public IWebElement GetMessageSelectedAge(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathMessageSelectedAge);

        public IWebElement GetCheckBox1(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCheckBox1);

        public IWebElement GetCheckBox2(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCheckBox2);

        public IWebElement GetCheckBox3(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCheckBox3);

        public IWebElement GetCheckBox4(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCheckBox4);

        public IWebElement GetButtonCheck(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonCheck);
    }
}


