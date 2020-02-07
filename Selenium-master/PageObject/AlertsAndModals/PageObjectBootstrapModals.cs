using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.AlertsAndModals
{
    public class PageObjectBootstrapModals
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.AlertsAndModals.BootstrapModals");

        public const string XPathButtonLaunchSingleModal = "/html/body/div[2]/div/div[2]/div[1]/div/div/div[2]/a";
        public const string XPathButtonLaunchMultipleModal = "/html/body/div[2]/div/div[2]/div[2]/div/div/div[2]/a";

        public const string XPathModalSingleView = "//*[@id='myModal0']/div";
        public const string XPathModalButtonClose = "//*[@id='myModal0']/div/div/div[4]/a[1]";
        public const string XPathModalButtonSaveChanges = "//*[@id='myModal0']/div/div/div[4]/a[2]";

        public const string XPathModalMultipleView = "//*[@id='myModal']";
        public const string XPathModalMultipleButtonClose = "//*[@id='myModal']/div/div/div[4]/a[1]";
        public const string XPathModalMultipleButtonSaveChanges = "//*[@id='myModal']/div/div/div[4]/a[2]";
        public const string XPathModalMultipleButtonOpenLaunchModal = "//*[@id='myModal']/div/div/div[3]/a";

        public const string XPathModalInModalView = "//*[@id='myModal2']/div";
        public const string XPathModalInModalViewButtonClose = "//*[@id='myModal2']/div/div/div[6]/a[1]";
        public const string XPathModalInModalViewButtonSaveChanges = "//*[@id='myModal2']/div/div/div[6]/a[2]";


        public IWebElement GetButtonLaunchSingleModal(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonLaunchSingleModal);
        public IWebElement GetButtonLaunchMultipleModal(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonLaunchMultipleModal);

        public IWebElement GetModalViewSingle(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalSingleView);
        public IWebElement GetModalButtonClose(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalButtonClose);
        public IWebElement GetModalButtonSaveChanges(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalButtonSaveChanges);

        public IWebElement GetModalMultiple(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalMultipleView);
        public IWebElement GetModalMultipleButtonClose(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalMultipleButtonClose);
        public IWebElement GetModalMultipleButtonSaveChanges(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalMultipleButtonSaveChanges);
        public IWebElement GetModalMultipleButtonOpenLaunchModal(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalMultipleButtonOpenLaunchModal);

        public IWebElement GetModalInModalView(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalInModalView);
        public IWebElement GetModalInModalViewButtonClose(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalInModalViewButtonClose);
        public IWebElement GetModalInModalViewButtonSaveChanges(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathModalInModalViewButtonSaveChanges);

    }
}
