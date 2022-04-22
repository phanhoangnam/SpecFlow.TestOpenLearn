using OpenQA.Selenium;
using SpecFlow.TestOpenLearn.Drivers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.TestOpenLearn.PageObjects
{
    public interface ISearchResultsPageObject
    {
        string GetTitle();
    }

    public class SearchResultsPageObject : ISearchResultsPageObject
    {
        private readonly IBrowserDriver _browserDriver;

        public SearchResultsPageObject(IBrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        // Finding elements
        private IWebElement TitleElement => _browserDriver.Current.FindElement(By.XPath("//title[contains(text(),'Search - OpenLearn - Open University')]"));

        public string GetTitle()
        {
            var title = TitleElement.Text;
            return title;
        }
    }
}
