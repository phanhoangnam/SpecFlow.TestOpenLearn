using FluentAssertions;
using SpecFlow.TestOpenLearn.Drivers;
using SpecFlow.TestOpenLearn.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.TestOpenLearn.Steps
{
    [Binding]
    public sealed class OpenLearnStepDefinitions
    {
        private readonly IHomePageObject _homePageObject;
        //private readonly ISearchResultsPageObject _searchResultsPageObject;
        private readonly IBrowserDriver _browserDriver;
        
        public OpenLearnStepDefinitions(IHomePageObject homePageObject, IBrowserDriver browserDriver)
        {
            _homePageObject = homePageObject;
            _browserDriver = browserDriver;
            //_searchResultsPageObject = searchResultsPageObject;
        }

        #region AC1
        [Given(@"I go to Openlearn Home Page")]
        public void GivenIGoToOpenlearnHomePage()
        {
            _browserDriver.Current.Navigate().GoToUrl(_homePageObject.HomeUrl);
        }

        [Then(@"I can see all items as the attached picture")]
        public void ThenICanSeeAllItemsAsTheAttachedPicture()
        {
            bool result = _homePageObject.VisibleAllElement();
            Console.WriteLine($"result: {result}");
            result.Should().Be(true);
        }
        #endregion

        #region AC3
        [Given(@"I enter (.*) into the search input with (.*)")]
        public void GivenIEnterSomethingIntoTheSearchInputWithXPath(string input, string xpath)
        {
            _homePageObject.EnterIntoInputSearch(input, xpath);
        }

        [When(@"I click  banner search button with (.*)")]
        public void WhenIClickBannerSearchButtonWithXPath(string xpath)
        {
            _homePageObject.ClickButtonSearch(xpath);
        }

        [Then(@"I see the search results page")]
        public void ThenITheSeeSearchResultsPage()
        {
            Console.WriteLine(_browserDriver.Current.Title);
            Console.WriteLine(_browserDriver.Current.Url);
            _browserDriver.Current.Url.Should().Contain("search-results");
            _browserDriver.Current.Title.Should().Be("Search - OpenLearn - Open University");
        }
        #endregion

    }
}
