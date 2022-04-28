using FluentAssertions;
using SpecFlow.TestOpenLearn.Drivers;
using SpecFlow.TestOpenLearn.PageObjects;
using System;
using System.Threading;
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
            _homePageObject.GetAltAttributeLogoElement().Should().Be("The Open University");
            _homePageObject.GetAltAttributeOpenLearnLogoElement().Should().Be("OpenLearn");
            _homePageObject.GetTextAttributeTagLineElement().Should().Be("Free learning from\r\nThe Open University");
            _homePageObject.GetTextAttributeTheOpenUniversityElement().Should().Be("The Open University");
            _homePageObject.GetTextAttributeStudyWithTheOpenUniversityElement().Should().Be("Study with The Open University");
            _homePageObject.GetTextAttributeSearchForElement().Should().Be("Search for");
            _homePageObject.GetPlaceholderAttributeSearchInputElement().Should().Be("Free courses, interactives, videos and more");
            _homePageObject.GetTitleAttributeButtonSearchElement().Should().Be("Search");
            _homePageObject.GetTextAttributeLinkHomeElement().Should().Be("Home");
            _homePageObject.GetTextAttributeLinkFreeCoursesElement().Should().Be("Free courses");
            _homePageObject.GetTextAttributeLinkSubjectsElement().Should().Be("Subjects");
            _homePageObject.GetTextAttributeLinkForStudyElement().Should().Be("For Study");
            _homePageObject.GetTextAttributeLinkForLifeElement().Should().Be("For Life");
            _homePageObject.GetTextAttributeLinkHelpElement().Should().Be("Help");
            _homePageObject.GetTitleAttributeLinkSignInElement().Should().Be("Create account / Sign in");
            _homePageObject.GetTextAttributeBannerHeadingElement().Should().Be("Dive in and start learning");
            _homePageObject.GetTextAttributeBannerSubHeadingElement().Should().Be("Everything on the multi-award winning OpenLearn is free to everyone!");
            _homePageObject.GetPlaceholderAttributeBannerSearchInputElement().Should().Be("Over 1000s of free courses, interactives, videos and more...");
            _homePageObject.GetTitleAttributeBannerButtonSearchElement().Should().Be("Search");
            _homePageObject.GetTitleAttributeButtonScrollElement().Should().Be("Scroll down to OpenLearn content");
        }
        #endregion

        #region AC3
        [Given(@"I enter (.*) into the search input with (.*)")]
        public void GivenIEnterSomethingIntoTheSearchInputWithXPath(string input, string xpath)
        {
            _homePageObject.EnterIntoElement(input, xpath);
        }

        [When(@"I click the search button with (.*)")]
        public void WhenIClickBannerSearchButtonWithXPath(string xpath)
        {
            _homePageObject.ClickElement(xpath);
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

        #region AC4
        [When(@"I click scroll down icon")]
        [Given(@"I click scroll down icon")]
        public void WhenIClickScrollDownIcon()
        {
            Console.WriteLine($"sticky menu: {_homePageObject.VisibleStickyMenu()}");
            _homePageObject.ClickScrollDownIcon();
            Thread.Sleep(2000);
        }

        [Then(@"the next section and the sticky menu is showing")]
        [Given(@"The sticky menu is showing")]
        public void ThenTheNextSectionAndTheStickyMenuIsShowing()
        {
            bool result = _homePageObject.VisibleStickyMenu();
            Console.WriteLine($"sticky menu: {result}");
            result.Should().Be(true);
        }
        #endregion

        #region AC5
        [When(@"I click the links in the sticky menu with (.*)")]
        public void WhenIClickTheLinksInTheStickyMenuWithXPath(string xpath)
        {
            _homePageObject.ClickElement(xpath);
            Thread.Sleep(1000);
        }

        [Then(@"They work correctly with (.*)")]
        public void ThenTheyWorkCorrectlyWithUrl(string url)
        {
            Console.WriteLine(_browserDriver.Current.Url);
            _browserDriver.Current.Url.Should().Be(url);
        }



        [When(@"I click the search icon")]
        public void WhenIClickTheSearchIcon()
        {
            _homePageObject.ClickSearchIconStickyElement();
            Thread.Sleep(1000);
        }

        [Then(@"The search box is shown")]
        public void ThenTheSearchBoxIsShown()
        {
            bool result = _homePageObject.VisibleSearchSticky();
            result.Should().Be(true);
        }

        [When(@"I enter (.*) into the search input")]
        public void WhenIEnterVideosIntoTheSearchInput(string input)
        {
            _homePageObject.EnterIntoInputSearch(input);
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            _homePageObject.ClickButtonSearch();
        }

        #region get inspired
        [Then(@"I'll check card item of the home page")]
        public void ThenILlCheckCardItemOfTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"I check text and click link get inspired (.*)")]
        public void ThenICheckTextAndClickLinkGetInspired(string xpath)
        {
            //Check all text
            _homePageObject.CheckAllTextAndIcon(xpath);
            //click link get inspired
            _homePageObject.ClickElement(xpath);

            Thread.Sleep(3000);
        }

        #endregion

        #endregion
    }
}
