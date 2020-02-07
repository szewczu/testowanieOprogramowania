
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.AlertsAndModals;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.AlertsAndModals
{
    public class BootstrapAlerts
    {
        private readonly PageObjectBootstrapAlerts _pageObjects = new PageObjectBootstrapAlerts();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;

            Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html", $"Page not exist \n Current:{url}\n Expected:https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html");
        }

        [Theory]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableSuccesMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableSuccesMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableDangerMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableDangerMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableWarningMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableWarningMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableInfoMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableInfoMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonNormalSuccessMessage, PageObjectBootstrapAlerts.XPathAlertsNormalSuccessMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonNormalDangerMessage, PageObjectBootstrapAlerts.XPathAlertsNormalDangerMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonNormalWarningMessage, PageObjectBootstrapAlerts.XPathAlertsNormalWarningMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonNormalInfoMessage, PageObjectBootstrapAlerts.XPathAlertsNormalInfoMessage)]
        public void CheckIfMessageDisplay(string xPathButton, string xPathAlert)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.GetWebElement(driver, xPathButton).Click();
            bool isElementDisplayed = Helpers.GetWebElement(driver, xPathAlert).Displayed;
            string elementsName = RetriveNamefromXPath(xPathButton);

            Helpers.AssertTrue(driver, isElementDisplayed, $"Alerts {elementsName} is not displayed");
        }

        [Theory]
        [InlineData(5, PageObjectBootstrapAlerts.XPathButtonAutocloseableSuccesMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableSuccesMessage)]
        [InlineData(5, PageObjectBootstrapAlerts.XPathButtonAutocloseableDangerMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableDangerMessage)]
        [InlineData(3, PageObjectBootstrapAlerts.XPathButtonAutocloseableWarningMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableWarningMessage)]
        [InlineData(6, PageObjectBootstrapAlerts.XPathButtonAutocloseableInfoMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableInfoMessage)]
        public void CheckAutocloseableAlertsClose(int visibilityTimeInSecond, string xPathButton, string xPathAlert)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.GetWebElement(driver, xPathButton).Click();
            bool isTimeOfVisibilityCorrect = WaitForAlertClose(visibilityTimeInSecond, xPathAlert, driver);

            string elementsName = RetriveNamefromXPath(xPathButton);

            Helpers.AssertTrue(driver, isTimeOfVisibilityCorrect, $"Alerts {elementsName} is not correct displayed for {visibilityTimeInSecond} seconds.");
        }

        [Theory]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableSuccesMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableDangerMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableWarningMessage)]
        [InlineData(PageObjectBootstrapAlerts.XPathButtonAutocloseableInfoMessage)]
        public void CheckIfButtonIsDisabledWhenClickOnAoutcloseableButton(string xPathButton)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.GetWebElement(driver, xPathButton).Click();
            bool isDisabled = Helpers.GetWebElement(driver, xPathButton).Enabled;

            string elementsName = RetriveNamefromXPath(xPathButton);

            Helpers.AssertFalse(driver, isDisabled, $"Button {elementsName} is enabled when should be disabled.");
        }


        private bool CheckIfAlertsIsNotDisplayedBeforeEndOfTime(IWebElement alert, int visibilityTimeInHalfSecond, int counterOfWaitLoop)
        {
            return !alert.Displayed && visibilityTimeInHalfSecond > counterOfWaitLoop;
        }
        private bool CheckIfAlertIsNotDisplayedInRightTime(IWebElement alert, int visibilityTimeInHalfSecond, int counterOfWaitLoop)
        {
            return !alert.Displayed && visibilityTimeInHalfSecond == counterOfWaitLoop;
        }
        private bool CheckIfAlertIsDisplayedAfterVisibilityTime(IWebElement alert, int visibilityTimeInHalfSecond, int counterOfWaitLoop)
        {
            return (alert.Displayed && visibilityTimeInHalfSecond < counterOfWaitLoop) ||
                   visibilityTimeInHalfSecond < counterOfWaitLoop;
        }

        private bool WaitForAlertClose(int visibilityTime, string xPathAlert, ChromeDriver driver)
        {
            int counterOfWaitLoop = 1;
            bool isTimeOfVisibilityCorrect = false;

            while (counterOfWaitLoop <= 20)
            {
                Thread.Sleep(1100); // slight margin of error
                var alert = Helpers.GetWebElement(driver, xPathAlert);
                if (CheckIfAlertsIsNotDisplayedBeforeEndOfTime(alert, visibilityTime,
                    counterOfWaitLoop))
                {
                    break;
                }
                else if (CheckIfAlertIsDisplayedAfterVisibilityTime(alert, visibilityTime,
                    counterOfWaitLoop))
                {
                    break;
                }
                else if (CheckIfAlertIsNotDisplayedInRightTime(alert, visibilityTime,
                    counterOfWaitLoop))
                {
                    isTimeOfVisibilityCorrect = true;
                    break;
                }

                counterOfWaitLoop++;
            }

            return isTimeOfVisibilityCorrect;
        }

        private string RetriveNamefromXPath(string xPath)
        {
            string name = xPath.Remove(0, 9);
            return name.Remove(name.Length - 2, 2);
        }

    }

}
