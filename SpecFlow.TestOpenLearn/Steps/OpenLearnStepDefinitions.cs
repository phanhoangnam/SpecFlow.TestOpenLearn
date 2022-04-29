using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.TestOpenLearn.Drivers;
using SpecFlow.TestOpenLearn.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

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
        #endregion


        #region Get inspired section
        #region AC1
        [Then(@"I see section title")]
        public void ThenISeeSectionTitle()
        {
            string title = _homePageObject.GetTextSectionTitle();
            Console.WriteLine($"title: {title}");
            title.Should().Be("Get inspired and learn something new today");
        }

        [Then(@"I see (.*) blocks")]
        public void ThenISeeBlocks(int number)
        {
            int blocksCount = _homePageObject.CountBlockElements();
            Console.WriteLine($"blocksCount: {blocksCount}");
            blocksCount.Should().Be(number);
        }

        [Then(@"Each block has elements fully")]
        public void ThenEachBlockHasElementsFully()
        {
            bool result = true;
            ReadOnlyCollection<IWebElement> imageElements = _homePageObject.GetElements("//div[contains(@class, \"box-image\")]");
            ReadOnlyCollection<IWebElement> copyrightElements = _homePageObject.GetElements("//span[contains(@class, \"img_permissions_icon emulate-link-focus copyright-icon\")]");
            ReadOnlyCollection<IWebElement> subjectTitleElements = _homePageObject.GetElements("//p[contains(@class, \"subject-name\")]");
            ReadOnlyCollection<IWebElement> blockTitleElements = _homePageObject.GetElements("//h3[contains(@class, \"content-title\")]");
            ReadOnlyCollection<IWebElement> blockDescriptionElements = _homePageObject.GetElements("//p[contains(@class, \"dotdot content-text\")]");
            
            for(int i = 0; i < 8; i++)
            {
                copyrightElements[i].Click();
                result = result
                        && imageElements[i].Displayed
                        && copyrightElements[i].Displayed
                        && subjectTitleElements[i].Displayed
                        && blockTitleElements[i].Displayed
                        && blockDescriptionElements[i].Displayed;
                Console.WriteLine($"result: {result}");
            }
            result.Should().Be(true);
        }

        #endregion

        #region AC2
        [When(@"I click link title section")]
        public void WhenIClickLinkTitleSection()
        {
            _homePageObject.ClickSectionTitle();
            Thread.Sleep(3000);
        }

        [Then(@"The link work correctly")]
        public void ThenTheLinkWorkCorrectly()
        {
            string url = _browserDriver.Current.Url;
            Console.WriteLine($"url: {url}");
            url.Should().Be("https://www.open.edu/openlearn/latest-from-openlearn");
        }

        #endregion

        #region AC3
        [When(@"I click Copy Right icon")]
        public void WhenIClickCopyRightIcon()
        {
            ReadOnlyCollection<IWebElement> copyrightIconElements = _homePageObject.GetElements("//span[contains(@class, \"img_permissions_icon emulate-link-focus copyright-icon\")]");
            foreach (IWebElement item in copyrightIconElements)
            {
                item.Click();
                Console.WriteLine("Clicked");
                Thread.Sleep(2000);
            }
        }

        [Then(@"The text of copyright is shown")]
        public void ThenTheTextOfCopyrightIsShown()
        {
            bool result = true;
            ReadOnlyCollection<IWebElement> attributeElements = _homePageObject.GetElements("//span[contains(@class, \"img_permissions_text\")]");
            foreach (IWebElement item in attributeElements)
            {
                result = result && item.Displayed;
                Console.WriteLine($"result: {result}");
            }
            result.Should().Be(true);
        }

        #endregion

        #region AC4
        private List<string> urlFromImage = new List<string>();
        private List<string> urlFromBlockTitle = new List<string>();
        [When(@"I click the image")]
        public void WhenIClickTheImage()
        {
            ReadOnlyCollection<IWebElement> imageElements = _homePageObject.GetElements("//div[contains(@class, \"box-image\")]");
            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine($"item: {imageElements[i]}");
                imageElements[i].Click();
                Thread.Sleep(2000);
                urlFromImage.Add(_browserDriver.Current.Url);
                _browserDriver.Current.Navigate().Back();
                //Thread.Sleep(3000);
                WebDriverWait wait = new WebDriverWait(_browserDriver.Current, TimeSpan.FromSeconds(10));
                imageElements = wait.Until(x => x.FindElements(By.XPath("//div[contains(@class, \"box-image\")]")));
            }
        }

        [When(@"I click block title")]
        public void WhenIClickBlockTitle()
        {
            ReadOnlyCollection<IWebElement> blockTitleElements = _homePageObject.GetElements("//h3[contains(@class, \"content-title\")]");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"item: {blockTitleElements[i]}");
                blockTitleElements[i].Click();
                Thread.Sleep(2000);
                urlFromBlockTitle.Add(_browserDriver.Current.Url);
                _browserDriver.Current.Navigate().Back();
                //Thread.Sleep(3000);
                WebDriverWait wait = new WebDriverWait(_browserDriver.Current, TimeSpan.FromSeconds(10));
                blockTitleElements = wait.Until(x => x.FindElements(By.XPath("//h3[contains(@class, \"content-title\")]")));
            }
        }

        [Then(@"I should be navigated to the same page")]
        public void ThenIShouldBeNavigatedToTheSamePage()
        {
            bool result = true;
            for(int i = 0; i < 8; i++)
            {
                if (urlFromImage[i] != urlFromBlockTitle[i])
                {
                    result = false;
                    break;
                }
            }
            result.Should().Be(true);
        }

        #endregion
        #endregion
    }
}
