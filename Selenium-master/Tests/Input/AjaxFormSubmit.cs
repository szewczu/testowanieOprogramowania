using System.Threading;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class AjaxFormSubmit
    {
        private readonly PageObjectAjaxFormSubmit _pageObjects = new PageObjectAjaxFormSubmit();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
             
             Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/ajax-form-submit-demo.html", $"Page not exist \n Current:{url}\n Expected:https://www.seleniumeasy.com/test/basic-radiobutton-demo.html ");
        }

        [Fact]
        public void SubmitEmptyForm()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            bool isSubmitButtonHidden = _pageObjects.GetSubmitButton(driver).Displayed;

            _pageObjects.GetSubmitButton(driver).Click();
            bool isValidationDisplayed = _pageObjects.GetNameValidation(driver).Displayed;

             Helpers.AssertTrue(driver, isValidationDisplayed, "Validations is not displayed");
             Helpers.AssertTrue(driver, isSubmitButtonHidden, "Button is not displayed");
        }

        [Fact]
        public void SubmitFilledForm()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.WriteText(_pageObjects.GetNameInput(driver), "Test Name");
            Helpers.WriteText(_pageObjects.GetCommentInput(driver), "Test Comment");
            bool isSubmitButtonHidden = _pageObjects.GetSubmitButton(driver).Displayed;

            _pageObjects.GetSubmitButton(driver).Click();

            bool isValidationDisplayed = _pageObjects.GetNameValidation(driver).Displayed;

            Helpers.AssertFalse(driver,isValidationDisplayed, "Validations is  displayed");
             Helpers.AssertTrue(driver, isSubmitButtonHidden, "Button is displayed");
        }

        [Fact]
        public void AjaxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string expectedMessage = "Ajax Request is Processing!";

            Helpers.WriteText(_pageObjects.GetNameInput(driver), "Test Name");
            _pageObjects.GetSubmitButton(driver).Click();

            string message = _pageObjects.GetDisplayMessage(driver).Text;

            Helpers.AssertTrue(driver, expectedMessage == message, $"Message is not valid.\nExpected:{expectedMessage}\nCurrent:{message}");
        }

        [Fact]
        public void DisplayedMessage()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string expectedMessage = "Form submited Successfully!";

            Helpers.WriteText(_pageObjects.GetNameInput(driver), "Test Name");
            _pageObjects.GetSubmitButton(driver).Click();

            string message = WaitForCorrectResponse(driver, expectedMessage);

            Helpers.AssertTrue(driver, expectedMessage == message, $"Message is not valid.\nExpected:{expectedMessage}\nCurrent:{message}");
        }

        [Fact]
        public void DisplayedAjaxIcon()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.WriteText(_pageObjects.GetNameInput(driver), "Test Name");
            _pageObjects.GetSubmitButton(driver).Click();
            Thread.Sleep(400);
            bool isIconDisplayed = _pageObjects.GetAjaxIcon(driver).Displayed;

            Helpers.AssertTrue(driver, isIconDisplayed, $"Ajax icon is not displayed.");
        }

        private string WaitForCorrectResponse(ChromeDriver driver, string expectedMessage)
        {
            int waitCounter = 0;
            string message = null;

            while (waitCounter < 4)
            {
                message = _pageObjects.GetDisplayMessage(driver).Text;
                if (message == expectedMessage)
                {
                    break;
                }
                ++waitCounter;
                Thread.Sleep(500);
            }
            return message;
        }
    }
}



