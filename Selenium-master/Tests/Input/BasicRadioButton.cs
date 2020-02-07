using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class BasicRadioButton
    {
        private readonly PageObjectBasicRadioButton _pageObjects = new PageObjectBasicRadioButton();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
             
            Helpers.AssertTrue(driver,url == "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html", $"Page not exist \n Current:{url}\n Expected:https://www.seleniumeasy.com/test/basic-radiobutton-demo.html ");
        }


        [Fact]
        public void ClickButtonWithoutCheckedAnyRadioButton()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.GetWebElement(driver, PageObjectBasicRadioButton.XPathButtonGetCheckedValue).Click();
            string result = _pageObjects.GetDisplayFirstMessage(driver).Text;

             
            Helpers.AssertTrue(driver,result == "Radio button is Not checked", $"Button text is not as expected \n Expected: Checked value \n Current: {result}");
        }

        [Fact]
        public void ClickGroupButtonWithoutCheckedAnyRadioButton()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetGroupButtonGetValues(driver).Click();
            string result = _pageObjects.GetGroupDisplay(driver).Text;
            string expectedResult = "Sex :\r\nAge group:";

             
            Helpers.AssertTrue(driver,result == expectedResult, $"Button text is not as expected \n Expected: {expectedResult}\n Current: {result}");
        }

        [Theory]
        [InlineData(PageObjectBasicRadioButton.XPathRadioButtonMale, "Male")]
        [InlineData(PageObjectBasicRadioButton.XPathRadioButtonFemale, "Female")]
        public void SelectRadioButtonAndCheckDisplayedText(string radioButton, string gender)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            Helpers.GetWebElement(driver, radioButton).Click();
            _pageObjects.GetButtonGetCheckedValue(driver).Click();

            string result = _pageObjects.GetDisplayFirstMessage(driver).Text;

             
            Helpers.AssertTrue(driver,result == $"Radio button '{gender}' is checked", $"Button text is not as expected \n Expected: Checked value \n Current: {result}");
        }

        [Theory]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonMale, null, "Sex : Male\r\nAge group:")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonMale, PageObjectBasicRadioButton.XPathGroupRadioButtonAge0To5, "Sex : Male\r\nAge group: 0 - 5")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonMale, PageObjectBasicRadioButton.XPathGroupRadioButtonAge5To15, "Sex : Male\r\nAge group: 5 - 15")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonMale, PageObjectBasicRadioButton.XPathGroupRadioButtonAge15To50, "Sex : Male\r\nAge group: 15 - 50")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonFemale, null, "Sex : Female\r\nAge group:")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonFemale, PageObjectBasicRadioButton.XPathGroupRadioButtonAge0To5, "Sex : Female\r\nAge group: 0 - 5")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonFemale, PageObjectBasicRadioButton.XPathGroupRadioButtonAge5To15, "Sex : Female\r\nAge group: 5 - 15")]
        [InlineData(PageObjectBasicRadioButton.XPathGroupRadioButtonFemale, PageObjectBasicRadioButton.XPathGroupRadioButtonAge15To50, "Sex : Female\r\nAge group: 15 - 50")]
        [InlineData(null, PageObjectBasicRadioButton.XPathGroupRadioButtonAge0To5, "Sex :\r\nAge group: 0 - 5")]
        [InlineData(null, PageObjectBasicRadioButton.XPathGroupRadioButtonAge5To15, "Sex :\r\nAge group: 5 - 15")]
        [InlineData(null, PageObjectBasicRadioButton.XPathGroupRadioButtonAge15To50, "Sex :\r\nAge group: 15 - 50")]
        public void CheckDisplayMessageOfGroupRadioButton(string xPathGender, string xPathAge, string expectedMessage)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            if (xPathGender != null)
            {
                Helpers.GetWebElement(driver, xPathGender).Click();
            }

            if (xPathAge != null)
            {
                Helpers.GetWebElement(driver, xPathAge).Click();
            }
            _pageObjects.GetGroupButtonGetValues(driver).Click();

            string result = _pageObjects.GetGroupDisplay(driver).Text;

             
            Helpers.AssertTrue(driver,result == expectedMessage, $"Result is not correct \nExpected:{expectedMessage}\nCurrent:{result}");
        }


    }
}
