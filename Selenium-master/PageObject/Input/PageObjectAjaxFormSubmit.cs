using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Input
{
    public class PageObjectAjaxFormSubmit
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.AjaxForm");

        public const string XPathNameLabel = "//*[@id='frm']/div[1]/label";
        public const string XPathNameInput = "//*[@id='title']";
        public const string XPathCommentLabel = "//*[@id='frm']/div[2]/label";
        public const string XPathCommentInput = "//*[@id='description']";
        public const string XPathSubmitButton = "//*[@id='btn-submit']";
        public const string XPathDisplayMessage = "//*[@id='submit-control']";
        public const string XPathAjaxIcon = "//*[@id='submit-control']/img";
        public const string XPathNameValidation = "//*[@id='frm']/div[1]/span";

        public IWebElement GetNameLabel(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNameLabel);

        public IWebElement GetNameInput(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNameInput);

        public IWebElement GetCommentLabel(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCommentLabel);

        public IWebElement GetCommentInput(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCommentInput);

        public IWebElement GetSubmitButton(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSubmitButton);

        public IWebElement GetDisplayMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplayMessage);

        public IWebElement GetAjaxIcon(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAjaxIcon);

        public IWebElement GetNameValidation(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNameValidation);
    }
}
