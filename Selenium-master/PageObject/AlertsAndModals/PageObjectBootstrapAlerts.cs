using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.AlertsAndModals
{
    public  class PageObjectBootstrapAlerts
    {
        public  readonly string PageUrl = Helpers.GetValueFromSettings("..Page.AlertsAndModals.BootstrapAlerts");

        public const string XPathButtonAutocloseableSuccesMessage = "//*[@id='autoclosable-btn-success']";
        public const string XPathButtonNormalSuccessMessage = "//*[@id='normal-btn-success']";
        public const string XPathButtonAutocloseableWarningMessage = "//*[@id='autoclosable-btn-warning']";
        public const string XPathButtonNormalWarningMessage = "//*[@id='normal-btn-warning']";
        public const string XPathButtonAutocloseableDangerMessage = "//*[@id='autoclosable-btn-danger']";
        public const string XPathButtonNormalDangerMessage = "//*[@id='normal-btn-danger']";
        public const string XPathButtonAutocloseableInfoMessage = "//*[@id='autoclosable-btn-info']";
        public const string XPathButtonNormalInfoMessage = "//*[@id='normal-btn-info']";

        public const string XPathAlertsAutocloseableSuccesMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[1]";
        public const string XPathAlertsNormalSuccessMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[2]";
        public const string XPathAlertsAutocloseableWarningMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[3]";
        public const string XPathAlertsNormalWarningMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[4]";
        public const string XPathAlertsAutocloseableDangerMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[5]";
        public const string XPathAlertsNormalDangerMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[6]";
        public const string XPathAlertsAutocloseableInfoMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[7]";
        public const string XPathAlertsNormalInfoMessage = "/html/body/div[2]/div/div[2]/div/div[2]/div[8]";

        public IWebElement GetButtonAutocloseableSuccesMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonAutocloseableSuccesMessage);
        public IWebElement GetButtonNormalSuccessMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonNormalSuccessMessage);
        public IWebElement GetButtonAutocloseableWarningMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonAutocloseableWarningMessage);
        public IWebElement GetButtonNormalWarningMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonNormalWarningMessage);
        public IWebElement GetButtonAutocloseableDangerMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonAutocloseableDangerMessage);
        public IWebElement GetButtonNormalDangerMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonNormalDangerMessage);
        public IWebElement GetButtonAutocloseableInfoMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonAutocloseableInfoMessage);
        public IWebElement GetButtonNormalInfoMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonNormalInfoMessage);
        public IWebElement GetAlertsAutocloseableSuccesMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsAutocloseableSuccesMessage);
        public IWebElement GetAlertsNormalSuccessMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsNormalSuccessMessage);
        public IWebElement GetAlertsAutocloseableWarningMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsAutocloseableWarningMessage);
        public IWebElement GetAlertsNormalWarningMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsNormalWarningMessage);
        public IWebElement GetAlertsAutocloseableDangerMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsAutocloseableDangerMessage);
        public IWebElement GetAlertsNormalDangerMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsNormalDangerMessage);
        public IWebElement GetAlertsAutocloseableInfoMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsAutocloseableInfoMessage);
        public IWebElement GetAlertsNormalInfoMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAlertsNormalInfoMessage);

    }
}
