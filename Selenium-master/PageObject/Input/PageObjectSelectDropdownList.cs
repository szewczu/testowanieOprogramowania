using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Input
{
    public class PageObjectSelectDropdownList
    {
        public enum EnumSelectListValues
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        public readonly IList<string> ListOfMultiSelectValue = new ReadOnlyCollection<string>
        (new List<string> {
            "California","Florida","New Jersey","New York","Ohio","Texas","Pennsylvania","Washington"
        });

        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.DropdownList");

        public const string XPathSelectListDropdown = "//*[@id='select-demo']";
        public const string XPathDisplaySelectListValue = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/p[2]";
        public const string XPathSelectMultiListDropdown = "//*[@id='multi-select']";
        public const string XPathButtonFirstSelect = "//*[@id='printMe']";
        public const string XPathButtonGetAllSelected = "//*[@id='printAll']";
        public const string XPathDisplayMultiSelectDropdown = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/p[2]";

        public IWebElement GetDisplaySelectListValue(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplaySelectListValue);
        public IWebElement GetButtonFirstSelect(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonFirstSelect);
        public IWebElement GetButtonGetAllSelected(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonGetAllSelected);
        public IWebElement GetDisplayMultiSelectDropdown(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplayMultiSelectDropdown);

        public SelectElement GetSelectListDropdown(ChromeDriver driver)
        {
            IWebElement element = Helpers.GetWebElement(driver, XPathSelectListDropdown);
            SelectElement dropdownList = new SelectElement(element);
            return dropdownList;
        }
        public SelectElement GetSelectMultiListDropdown(ChromeDriver driver)
        {
            IWebElement element = Helpers.GetWebElement(driver, XPathSelectMultiListDropdown);
            SelectElement dropdownList = new SelectElement(element);
            return dropdownList;
        }
    }
}
