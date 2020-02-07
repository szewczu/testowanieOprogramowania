
using System.Threading;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.AlertsAndModals;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.AlertsAndModals
{
    public class BootstrapModals
    {
        private readonly PageObjectBootstrapModals _pageObjects = new PageObjectBootstrapModals();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;

            Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/bootstrap-modal-demo.html", $"Page not exist \n Current:{url}\n Expected:https://www.seleniumeasy.com/test/bootstrap-modal-demo.html");
        }


        [Theory]
        [InlineData("SingleModal", PageObjectBootstrapModals.XPathButtonLaunchSingleModal, PageObjectBootstrapModals.XPathModalSingleView)]
        [InlineData("MultipleModal", PageObjectBootstrapModals.XPathButtonLaunchMultipleModal, PageObjectBootstrapModals.XPathModalMultipleView)]
        public void OpenModal(string modal, string xPathButton, string xPathModalView)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            Helpers.GetWebElement(driver, xPathButton).Click();
            Thread.Sleep(500);
            bool isModalDisplayed = Helpers.GetWebElement(driver, xPathModalView).Displayed;

            Helpers.AssertTrue(driver, isModalDisplayed, $"Modal {modal} is not displayed");
        }

        [Fact]
        public void CloseSingleModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetButtonLaunchSingleModal(driver).Click();
            Thread.Sleep(500);
            _pageObjects.GetModalButtonClose(driver).Click();

            bool isModalDisplayed = WaitForSingleModalDisappear(driver);

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not close");
        }

        [Fact]
        public void CloseMultipleModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonLaunchMultipleModal(driver).Click();
            Thread.Sleep(500);
            _pageObjects.GetModalMultipleButtonClose(driver).Click();

            bool isModalDisplayed = WaitForMultipleModalDisappear(driver);

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not close");
        }

        [Fact]
        public void SaveSingleModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetButtonLaunchSingleModal(driver).Click();

            Thread.Sleep(500);
            _pageObjects.GetModalButtonSaveChanges(driver).Click();

            bool isModalDisplayed = WaitForSingleModalDisappear(driver);

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not saved");
        }

        [Fact]
        public void SaveMultipleModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetButtonLaunchMultipleModal(driver).Click();

            Thread.Sleep(500);
            _pageObjects.GetModalMultipleButtonSaveChanges(driver).Click();

            bool isModalDisplayed = WaitForMultipleModalDisappear(driver);

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not saved");
        }

        [Fact]
        public void OpenModalInModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetButtonLaunchMultipleModal(driver).Click();
            Thread.Sleep(500);
            _pageObjects.GetModalMultipleButtonOpenLaunchModal(driver);
            Thread.Sleep(500);
            bool isModalDisplayed = _pageObjects.GetModalInModalView(driver).Displayed;

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not saved");
        }

        [Fact]
        public void CloseModalInModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonLaunchMultipleModal(driver).Click();
            Thread.Sleep(500);
            _pageObjects.GetModalMultipleButtonOpenLaunchModal(driver).Click();
            Thread.Sleep(500);

            _pageObjects.GetModalInModalViewButtonClose(driver).Click();

            bool isModalDisplayed = WaitForModalInModalDisappear(driver);
            bool isModalMultipleDisplayed = _pageObjects.GetModalMultiple(driver).Displayed;

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not closed");
            Helpers.AssertTrue(driver, isModalMultipleDisplayed, $"Multiple modal is closed");
        }

        [Fact]
        public void SaveModalInModal()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonLaunchMultipleModal(driver).Click();
            Thread.Sleep(500);
            _pageObjects.GetModalMultipleButtonOpenLaunchModal(driver).Click();
            Thread.Sleep(500);

            _pageObjects.GetModalInModalViewButtonSaveChanges(driver).Click();

            bool isModalDisplayed = WaitForModalInModalDisappear(driver);
            bool isModalMultipleDisplayed = _pageObjects.GetModalMultiple(driver).Displayed;

            Helpers.AssertFalse(driver, isModalDisplayed, $"Modal is not closed");
            Helpers.AssertFalse(driver, isModalMultipleDisplayed, $"Multiple modal is not closed");
        }

        private bool WaitForSingleModalDisappear(ChromeDriver driver)
        {
            int waitCounter = 0;
            bool isModalDisplayed = true;

            while (waitCounter < 20)
            {
                if (!_pageObjects.GetModalViewSingle(driver).Displayed)
                {
                    isModalDisplayed = false;
                    break;
                }
                Thread.Sleep(500);
                waitCounter++;
            }
            return isModalDisplayed;
        }

        private bool WaitForMultipleModalDisappear(ChromeDriver driver)
        {
            int waitCounter = 0;
            bool isModalDisplayed = true;

            while (waitCounter < 20)
            {
                if (!_pageObjects.GetModalMultiple(driver).Displayed)
                {
                    isModalDisplayed = false;
                    break;
                }
                Thread.Sleep(500);
                waitCounter++;
            }
            return isModalDisplayed;
        }

        private bool WaitForModalInModalDisappear(ChromeDriver driver)
        {
            int waitCounter = 0;
            bool isModalDisplayed = true;

            while (waitCounter < 20)
            {
                if (!_pageObjects.GetModalInModalView(driver).Displayed)
                {
                    isModalDisplayed = false;
                    break;
                }
                Thread.Sleep(500);
                waitCounter++;
            }
            return isModalDisplayed;
        }
    }
}
