using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Table;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Table
{
    public class TablePagination
    {
        private readonly PageObjectTablePagination _pageObjects = new PageObjectTablePagination();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
            Helpers.AssertTrue(driver,url == "https://www.seleniumeasy.com/test/table-pagination-demo.html", $"Page not exist \n Current:{url}\n Expected:https://www.seleniumeasy.com/test/table-pagination-demo.html");
        }

        [Fact]
        public void CheckCountOfRecords()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            IList<IWebElement> tableRows = _pageObjects.GetTableBody(driver).FindElements(By.TagName("tr"));
            int countOfTableRows = tableRows.Count;

            Helpers.AssertTrue(driver,countOfTableRows == 15, $"Table doesn't has expected number of row. \nExpected:15\nCurrent:{countOfTableRows}");
        }

        [Fact]
        public void IsPageButtonsExist()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            bool firstPage = _pageObjects.GetFirstPage(driver).Displayed;
            bool secondPage = _pageObjects.GetSecondPage(driver).Displayed;
            bool thirdPage = _pageObjects.GetThirdPage(driver).Displayed;

            Helpers.AssertTrue(driver,firstPage, "Button '1' not exist");
            Helpers.AssertTrue(driver,secondPage, "Button '2' not exist");
            Helpers.AssertTrue(driver,thirdPage, "Button '3' not exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnFirstPage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            bool nextButton = _pageObjects.GetNext(driver).Displayed;
            bool previousButton = _pageObjects.GetPrevious(driver).Displayed;

            Helpers.AssertTrue(driver,nextButton, "Button '>>' not exist");
            Helpers.AssertFalse(driver,previousButton, "Button '<<' exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnSecondPage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetSecondPage(driver).Click();
            bool nextButton = _pageObjects.GetNext(driver).Displayed;
            bool previousButton = _pageObjects.GetPrevious(driver).Displayed;

            Helpers.AssertTrue(driver,nextButton, "Button '>>' not exist");
            Helpers.AssertTrue(driver,previousButton, "Button '<<' not exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnThirdPage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetThirdPage(driver).Click();
            bool nextButton = _pageObjects.GetNext(driver).Displayed;
            bool previousButton = _pageObjects.GetPrevious(driver).Displayed;

            Helpers.AssertFalse(driver,nextButton, "Button '>>'  exist");
            Helpers.AssertTrue(driver,previousButton, "Button '<<' not exist");
        }
    }
}
