using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Table;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Table
{
    public class DataFilter
    {
        private readonly PageObjectDataFilter _pageObjects = new PageObjectDataFilter();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
            Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/table-records-filter-demo.html", $"Page not exist \n Current:{url}\n Expected:https://www.seleniumeasy.com/test/table-records-filter-demo.html");
        }

        [Fact]
        public void CheckNumberOfRecord()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            int numberOfRecords = ListOfElements(_pageObjects.GetTable(driver)).Count;

            Helpers.AssertTrue(driver, numberOfRecords == 5, $"Number of records is not correct\nExpected:5\nCurrent:{numberOfRecords}");
        }

        private IReadOnlyCollection<IWebElement> ListOfElements(IWebElement element)
        {
            return element.FindElements(By.TagName("tr"));
        }

        [Fact]
        public void CheckIfAllIsDeselected()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            var listOfElements = ListOfElements(_pageObjects.GetTable(driver));

            string message = "";

            for (int i = 0; i < listOfElements.Count;i++)
            {
               bool isSelected = listOfElements.ElementAt(i).FindElement(By.TagName("input")).Selected;
                if (isSelected)
                {
                    int elementNumber = i + 1;
                    message = message + elementNumber + ", ";
                }
            }

            Helpers.AssertTrue(driver, message == "", $"Record at position {message} are selected");
        }

        [Fact]
        public void CheckIfAllHasStarOff()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl); 

            var listOfElements = ListOfElements(_pageObjects.GetTable(driver));

            string message = "";

            for (int i = 0; i < listOfElements.Count; i++)
            {
               var  className =listOfElements.ElementAt(i).FindElement(By.TagName("a")).GetAttribute("class");
                if (className == "star star-checked")
                {
                    int elementNumber = i + 1;
                    message = message + elementNumber + ", ";
                }
            }

            Helpers.AssertTrue(driver, message == "", $"Record at position {message} are selected");
        }

        [Fact]
        public void ShowOnlyGreen() 
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonGreen(driver).Click();
            var list = ListOfElements(_pageObjects.GetTable(driver));

            var displayedList = GetListOfDisplayedElements(list);
            bool isAllGreen = CheckIfAllElementsHasSameText(displayedList,"(Green)");

            Helpers.AssertTrue(driver, isAllGreen, $"Not all elements are green");

        }

        [Fact]
        public void ShowOnlyOrange()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonOrange(driver).Click();
            var list = ListOfElements(_pageObjects.GetTable(driver));
            var displayedList = GetListOfDisplayedElements(list);

            bool isAllOrange = CheckIfAllElementsHasSameText(displayedList, "(Orange)");

            Helpers.AssertTrue(driver, isAllOrange, $"Not all elements are orange");

        }

        [Fact]
        public void ShowOnlyRed()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonRed(driver).Click();
            var list = ListOfElements(_pageObjects.GetTable(driver));
            var displayedList = GetListOfDisplayedElements(list);

            bool isAllRed = CheckIfAllElementsHasSameText(displayedList, "(Red)");

            Helpers.AssertTrue(driver, isAllRed, $"Not all elements are red");

        }

        [Fact]
        public void ShowOnlyAll() 
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetButtonAll(driver).Click();
            var list = ListOfElements(_pageObjects.GetTable(driver));

            int countOfElements = GetListOfDisplayedElements(list).Count;

            Helpers.AssertTrue(driver, countOfElements == 5, $"{countOfElements}Not all elements displayed");

        }

        private bool CheckIfAllElementsHasSameText(ICollection<IWebElement> displayedList, string expectedText)
        {
            foreach (var element in displayedList)
            {
                var text = element.FindElement(By.TagName("h4")).FindElement(By.TagName("span")).Text;
                if (text != expectedText)
                {
                    return false;
                }
            }
            return true;
        }

        private ICollection<IWebElement> GetListOfDisplayedElements(IReadOnlyCollection<IWebElement> list)
        {
            ICollection<IWebElement> displayedList = new List<IWebElement>();

            foreach (var element in list)
            {
                if (element.Displayed)
                {
                    displayedList.Add(element);
                }
            }
            return displayedList;
        }


    }
}
