using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class SimpleForm
    {
        private readonly PageObjectBasicForm _pageObjects = new PageObjectBasicForm();

        [Fact]
        public void CheckUrl()
        {

            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
            driver.Dispose();
            Assert.True(url == "https://www.seleniumeasy.com/test/basic-first-form-demo.htmlm", "Page not exist");
        }

        [Theory]
        [InlineData(PageObjectBasicForm.XPathTextBoxSum1)]
        [InlineData(PageObjectBasicForm.XPathTextBoxSum2)]
        public void InputNonNumberTextToSumTextBoxForm(string inputId)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            IWebElement element = driver.FindElementByXPath(inputId);
            Helpers.WriteText(element, "Test");
            _pageObjects.GetButtonSubmitSum(driver).Click();

            string result = Helpers.GetValue(element);

            driver.Dispose();
            Assert.True(result == "", $"Textbox {inputId} test failed. Value should be a number. \n Expected:\n Current: {result}");
        }


        [Theory]
        [InlineData("Test")]
        [InlineData("1234567890")]
        [InlineData("Test123")]
        [InlineData("     ")]
        [InlineData("")]
        public void SendMessageToFormGetInput(string text)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.WriteText(_pageObjects.GetTextBoxMessage(driver), text);
            _pageObjects.GetButtonSubmitMessage(driver).Click();

            string result = _pageObjects.GetDisplayMessage(driver).Text;

            driver.Dispose();
            Assert.True(result == text, $"Test failed. \n Expected: {text} \n Current: {result} ");
        }

        [Theory]
        [InlineData("1", "1", "2")]
        [InlineData("0", "0", "0")]
        [InlineData("2000000000", "2000000000", "4000000000")]

        [InlineData("-1", "-1", "-2")]
        [InlineData("-0", "-0", "0")]
        [InlineData("-2000000000", "-2000000000", "-4000000000")]

        [InlineData("1", "-1", "0")]
        [InlineData("0", "-0", "0")]
        [InlineData("2000000000", "-2000000000", "0")]

        [InlineData("10", "-1", "9")]
        [InlineData("-10", "1", "-9")]

        [InlineData("a", "b", "NaN")]
        [InlineData(" ", "b", "NaN")]
        [InlineData("a", " ", "NaN")]
        [InlineData(" ", " ", "NaN")]
        [InlineData("", "", "NaN")]

        [InlineData("1a", "1b", "NaN")]
        [InlineData("a", "1b", "NaN")]
        [InlineData("1a", "b", "NaN")]
        [InlineData("1.1", "1.1", "NaN")]
        public void SendMessageToFormGetTotal(string valueA, string valueB, string sum)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetTextBoxSum1(driver).SendKeys(valueA);
            _pageObjects.GetTextBoxSum2(driver).SendKeys(valueB);
            _pageObjects.GetButtonSubmitSum(driver).Click();
            string result = _pageObjects.GetDisplaySum(driver).Text;

            driver.Dispose();
            Assert.True(result == sum, $"Test failed. \n Expected: {sum} \n Current: {result} ");
        }
    }
}
