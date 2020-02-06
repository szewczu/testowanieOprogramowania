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
            Assert.True(url == "https://www.seleniumeasy.com/test/table-pagination-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/table-pagination-demo.html");
            driver.Dispose();
        }

        [Fact]
        public void CheckCountOfRecords()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            IList<IWebElement> tableRows = _pageObjects.GetTableBody(driver).FindElements(By.TagName("tr"));
            int countOfTableRows = tableRows.Count;

            driver.Dispose();
            Assert.True(countOfTableRows == 15, $"Table doesn't has expected number of row. \nExpected:15\nCurrent:{countOfTableRows}");
        }

        [Fact]
        public void IsPageButtonsExist()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            bool firstPage = _pageObjects.GetFirstPage(driver).Displayed;
            bool secondPage = _pageObjects.GetSecondPage(driver).Displayed;
            bool thirdPage = _pageObjects.GetThirdPage(driver).Displayed;

            driver.Dispose();
            Assert.True(firstPage, "Button '1' not exist");
            Assert.True(secondPage, "Button '2' not exist");
            Assert.True(thirdPage, "Button '3' not exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnFirstPage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            bool nextButton = _pageObjects.GetNext(driver).Displayed;
            bool previousButton = _pageObjects.GetPrevious(driver).Displayed;

            driver.Dispose();
            Assert.True(nextButton, "Button '>>' not exist");
            Assert.False(previousButton, "Button '<<' exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnSecondPage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetSecondPage(driver).Click();
            bool nextButton = _pageObjects.GetNext(driver).Displayed;
            bool previousButton = _pageObjects.GetPrevious(driver).Displayed;

            driver.Dispose();
            Assert.True(nextButton, "Button '>>' not exist");
            Assert.True(previousButton, "Button '<<' not exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnThirdPage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetThirdPage(driver).Click();
            bool nextButton = _pageObjects.GetNext(driver).Displayed;
            bool previousButton = _pageObjects.GetPrevious(driver).Displayed;

            driver.Dispose();
            Assert.False(nextButton, "Button '>>'  exist");
            Assert.True(previousButton, "Button '<<' not exist");
        }
    }
}
