using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class Checkbox
    {
        private readonly PageObjectBasicCheckbox _pageObjects = new PageObjectBasicCheckbox();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
            driver.Dispose();
            Assert.True(url == "https://www.seleniumeasy.com/test/basic-checkbox-demo.html", "Page not exist");
        }

        [Fact]
        public void CheckboxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetCheckBoxAge(driver).Click();
            string result = _pageObjects.GetMessageSelectedAge(driver).Text;

            driver.Dispose();
            Assert.True(result == "Success - Check box is checked", "Message is not correct");
        }


        [Theory]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox1)]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox2)]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox3)]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox4)]
        public void CheckButtonTextWhenSingleCheckboxIsSelected(string xPath)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            IWebElement checkBox = driver.FindElementByXPath(xPath);
            checkBox.Click();
            string result = Helpers.GetValue(_pageObjects.GetButtonCheck(driver));

            driver.Dispose();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void SelectRightFourCheckboxAndCheckMessage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetCheckBox1(driver).Click();
            _pageObjects.GetCheckBox2(driver).Click();
            _pageObjects.GetCheckBox3(driver).Click();
            _pageObjects.GetCheckBox4(driver).Click();

            string result = Helpers.GetValue(_pageObjects.GetButtonCheck(driver));

            driver.Dispose();
            Assert.True(result == "Uncheck All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void ClickUncheckAllButtonAndCheckText()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetCheckBox1(driver).Click();
            _pageObjects.GetCheckBox2(driver).Click();
            _pageObjects.GetCheckBox3(driver).Click();
            _pageObjects.GetCheckBox4(driver).Click();

            _pageObjects.GetButtonCheck(driver).Click();

            string result = Helpers.GetValue(_pageObjects.GetButtonCheck(driver));

            driver.Dispose();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void CheckButtonMessageWhenSelectedThreeRightAndOneWrongCheckBox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            _pageObjects.GetCheckBoxAge(driver).Click();
            _pageObjects.GetCheckBox2(driver).Click();
            _pageObjects.GetCheckBox3(driver).Click();
            _pageObjects.GetCheckBox4(driver).Click();

            string result = Helpers.GetValue(_pageObjects.GetButtonCheck(driver));

            driver.Dispose();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }


    }
}
