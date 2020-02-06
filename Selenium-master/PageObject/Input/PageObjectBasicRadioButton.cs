using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Input
{
    public class PageObjectBasicRadioButton
    {

        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.RadioButton");

        public const string XPathRadioButtonMale = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/label[1]/input";
        public const string XPathRadioButtonFemale = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/label[2]/input";
        public const string XPathButtonGetCheckedValue = "//*[@id='buttoncheck']";
        public const string XPathDisplayFirstMessage = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/p[3]";

        public const string XPathGroupRadioButtonMale = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label[1]/input";
        public const string XPathGroupRadioButtonFemale = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label[2]";
        public const string XPathGroupRadioButtonAge0To5 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label[1]/input";
        public const string XPathGroupRadioButtonAge5To15 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label[2]/input";
        public const string XPathGroupRadioButtonAge15To50 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label[3]/input";
        public const string XPathGroupButtonGetValues = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/button";
        public const string XPathGroupDisplay = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/p[2]";

        public IWebElement GetRadioButtonMale(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathRadioButtonMale);

        public IWebElement GetRadioButtonFemale(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathRadioButtonFemale);

        public IWebElement GetButtonGetCheckedValue(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonGetCheckedValue);

        public IWebElement GetDisplayFirstMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplayFirstMessage);

        public IWebElement GetGroupRadioButtonMale(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupRadioButtonMale);

        public IWebElement GetGroupRadioButtonFemale(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupRadioButtonFemale);

        public IWebElement GetGroupRadioButtonAge0To5(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupRadioButtonAge0To5);

        public IWebElement GetGroupRadioButtonAge5To15(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupRadioButtonAge5To15);

        public IWebElement GetGroupRadioButtonAge15To50(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupRadioButtonAge15To50);

        public IWebElement GetGroupButtonGetValues(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupButtonGetValues);

        public IWebElement GetGroupDisplay(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathGroupDisplay);
    }
}
