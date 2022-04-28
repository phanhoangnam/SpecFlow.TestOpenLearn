using FluentAssertions;
using OpenQA.Selenium;
using SpecFlow.TestOpenLearn.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.TestOpenLearn.PageObjects
{
    public interface IHomePageObject
    {
        string HomeUrl { get; }

        void ClickButtonSearch();
        void ClickElement(string xpath);
        void ClickScrollDownIcon();
        void ClickSearchIconStickyElement();
        void EnterIntoElement(string input, string xpath);
        void EnterIntoInputSearch(string input);
        string GetAltAttributeLogoElement();
        string GetAltAttributeOpenLearnLogoElement();
        string GetPlaceholderAttributeBannerSearchInputElement();
        string GetPlaceholderAttributeSearchInputElement();
        string GetTextAttributeBannerHeadingElement();
        string GetTextAttributeBannerSubHeadingElement();
        string GetTextAttributeLinkForLifeElement();
        string GetTextAttributeLinkForStudyElement();
        string GetTextAttributeLinkFreeCoursesElement();
        string GetTextAttributeLinkHelpElement();
        string GetTextAttributeLinkHomeElement();
        string GetTextAttributeLinkSubjectsElement();
        string GetTextAttributeSearchForElement();
        string GetTextAttributeStudyWithTheOpenUniversityElement();
        string GetTextAttributeTagLineElement();
        string GetTextAttributeTheOpenUniversityElement();
        string GetTitleAttributeBannerButtonSearchElement();
        string GetTitleAttributeButtonScrollElement();
        string GetTitleAttributeButtonSearchElement();
        string GetTitleAttributeLinkSignInElement();
        bool VisibleAllElement();
        bool VisibleSearchSticky();
        bool VisibleStickyMenu();
        void CheckAllTextAndIcon(string xpath);
    }

    public class HomePageObject : IHomePageObject
    {
        private readonly IBrowserDriver _browserDriver;

        public HomePageObject(IBrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        public string HomeUrl => "https://www.open.edu/openlearn/";

        // Finding elements
        private IWebElement LogoElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='main_header']//a[@class='hslogo logo-image']//img"));
        private IWebElement OpenLearnLogoElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='main_header']//div[@class='main-logo']//img"));
        private IWebElement TagLineElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='main_wrapper']//div[@class='tagline']//a[1]"));
        private IWebElement TheOpenUniversityElement => _browserDriver.Current.FindElement(By.XPath("//ul[@id='sbhsnavigation']//li[@class='first']//a[contains(text(),'The Open University')]"));
        private IWebElement StudyWithTheOpenUniversityElement => _browserDriver.Current.FindElement(By.XPath("//ul[@id='sbhsnavigation']//a[contains(text(),'Study with The Open University')]"));
        private IWebElement SearchForElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='main_header']//label[@class='main_search_label'][contains(text(),'Search for')]"));
        private IWebElement SearchInputElement => _browserDriver.Current.FindElement(By.XPath("//input[@id='main_search_text_header_sticky']"));
        private IWebElement ButtonSearchElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='main_header']//button[@class='search icon-search']"));
        private IWebElement LinkHomeElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='mainMenu-left']//a[contains(text(),'Home')]"));
        private IWebElement LinkFreeCoursesElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='mainMenu-left']//a[contains(text(),'Free courses')]"));
        private IWebElement LinkSubjectsElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='mainMenu-left']//a[contains(text(),'Subjects')]"));
        private IWebElement LinkForStudyElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='mainMenu-left']//a[contains(text(),'For Study')]"));
        private IWebElement LinkForLifeElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='mainMenu-left']//a[contains(text(),'For Life')]"));
        private IWebElement LinkHelpElement => _browserDriver.Current.FindElement(By.XPath("//div[@id='mainMenu-left']//a[contains(text(),'Help')]"));
        private IWebElement LinkSignInElement => _browserDriver.Current.FindElement(By.XPath("//a[@class='openlearnng_signin_signout btn-sidebar btn-olive']"));
        private IWebElement MainImageElement => _browserDriver.Current.FindElement(By.XPath("//div[@class='gradient-img']//img"));
        private IWebElement BannerHeadingElement => _browserDriver.Current.FindElement(By.XPath("//h1[@id='banner_search_label']"));
        private IWebElement BannerSubHeadingElement => _browserDriver.Current.FindElement(By.XPath("//p[@id='banner_search_sub_label']"));
        private IWebElement BannerSearchInputElement => _browserDriver.Current.FindElement(By.XPath("//input[@id='banner_search_text']"));
        private IWebElement BannerButtonSearchElement => _browserDriver.Current.FindElement(By.XPath("//a[@class='search']"));
        private IWebElement ButtonScrollElement => _browserDriver.Current.FindElement(By.XPath("//a[@id='scroll-content']"));
        private IWebElement StickyMenuElement => _browserDriver.Current.FindElement(By.XPath("//div[@class='main_sticky']"));
        private IWebElement SearchIconStickyElement => _browserDriver.Current.FindElement(By.XPath("//div[@class='link_search icon_link']//a"));
        private IWebElement SearchStickyElement => _browserDriver.Current.FindElement(By.XPath("//div[@class='search_box box_form show']"));
        private IWebElement SearchInputStickyElement => _browserDriver.Current.FindElement(By.XPath("//input[@id='main_search_text_header']"));
        private IWebElement SearchButtonStickyElement => _browserDriver.Current.FindElement(By.XPath("//div[@class='search_box box_form show']//button[@class='search icon-search']"));


        private IWebElement Element(string xpath) => _browserDriver.Current.FindElement(By.XPath($"{xpath}"));

        private IWebElement TextElementInspired => _browserDriver.Current.FindElement(By.XPath("//a[contains(text(),'Get inspired and learn something new today')]"));
        private IWebElement CopyFreeIcon => _browserDriver.Current.FindElement(By.XPath("//img[@alt='Copyright free Icon']"));
        private IWebElement CopyIcon => _browserDriver.Current.FindElement(By.XPath("//img[@alt='Copyrighted Icon']"));

        public bool VisibleAllElement()
        {
            return LogoElement.Displayed
                && OpenLearnLogoElement.Displayed
                && TagLineElement.Displayed
                && TheOpenUniversityElement.Displayed
                && StudyWithTheOpenUniversityElement.Displayed
                && SearchForElement.Displayed
                && SearchInputElement.Displayed
                && ButtonSearchElement.Displayed
                && LinkHomeElement.Displayed
                && LinkFreeCoursesElement.Displayed
                && LinkSubjectsElement.Displayed
                && LinkForStudyElement.Displayed
                && LinkForLifeElement.Displayed
                && LinkHelpElement.Displayed
                && LinkSignInElement.Displayed
                && MainImageElement.Displayed
                && BannerHeadingElement.Displayed
                && BannerSubHeadingElement.Displayed
                && BannerSearchInputElement.Displayed
                && BannerButtonSearchElement.Displayed
                && ButtonScrollElement.Displayed
                && TextElementInspired.Displayed;
        }

        public string GetAltAttributeLogoElement()
        {
            return LogoElement.GetAttribute("alt");
        }

        public string GetAltAttributeOpenLearnLogoElement()
        {
            return OpenLearnLogoElement.GetAttribute("alt");
        }

        public string GetTitleAttributeButtonSearchElement()
        {
            return ButtonSearchElement.GetAttribute("title");
        }

        public string GetTitleAttributeLinkSignInElement()
        {
            return LinkSignInElement.GetAttribute("title");
        }

        public string GetTitleAttributeBannerButtonSearchElement()
        {
            return BannerButtonSearchElement.GetAttribute("title");
        }

        public string GetTitleAttributeButtonScrollElement()
        {
            return ButtonScrollElement.GetAttribute("title");
        }

        public string GetTextAttributeTagLineElement()
        {
            return TagLineElement.Text;
        }

        public string GetTextAttributeTheOpenUniversityElement()
        {
            return TheOpenUniversityElement.Text;
        }
        public string GetTextAttributeStudyWithTheOpenUniversityElement()
        {
            return StudyWithTheOpenUniversityElement.Text;
        }
        public string GetTextAttributeSearchForElement()
        {
            return SearchForElement.Text;
        }
        public string GetPlaceholderAttributeSearchInputElement()
        {
            return SearchInputElement.GetAttribute("placeholder");
        }
        public string GetTextAttributeLinkHomeElement()
        {
            return LinkHomeElement.Text;
        }
        public string GetTextAttributeLinkFreeCoursesElement()
        {
            return LinkFreeCoursesElement.Text;
        }
        public string GetTextAttributeLinkSubjectsElement()
        {
            return LinkSubjectsElement.Text;
        }
        public string GetTextAttributeLinkForStudyElement()
        {
            return LinkForStudyElement.Text;
        }
        public string GetTextAttributeLinkForLifeElement()
        {
            return LinkForLifeElement.Text;
        }
        public string GetTextAttributeLinkHelpElement()
        {
            return LinkHelpElement.Text;
        }
        public string GetTextAttributeBannerHeadingElement()
        {
            return BannerHeadingElement.Text;
        }
        public string GetTextAttributeBannerSubHeadingElement()
        {
            return BannerSubHeadingElement.Text;
        }
        public string GetPlaceholderAttributeBannerSearchInputElement()
        {
            return BannerSearchInputElement.GetAttribute("placeholder");
        }

        public void EnterIntoElement(string input, string xpath)
        {
            Element(xpath).Clear();
            Element(xpath).SendKeys(input);
        }
        public void ClickElement(string xpath)
        {          
            Element(xpath).Click();    
        }

        public void CheckAllTextAndIcon(string xpath)
        {
            //Get inspired and learn something new today
            var a = Element(xpath).Text.Should().Be("Get inspired and learn something new today");
            Thread.Sleep(3000);
            Console.WriteLine($"TextInspiredElement: {a}");

            //CopyFreeIcon
            var freeIcon = CopyFreeIcon.GetAttribute("alt");
            var resultCopyFreeIcon = CopyFreeIcon.Should().Be("Copyright free Icon");
            Thread.Sleep(3000);
            Console.WriteLine($"Copyright free Icon: {resultCopyFreeIcon}");
           

            //Copyrighted Icon
            var CopyrightedIcon = CopyIcon.GetAttribute("alt");
            var resultCopyrightedIcon = CopyrightedIcon.Should().Be("Copyrighted Icon");
            Thread.Sleep(3000);
            Console.WriteLine($"Copyrighted Icon: {resultCopyrightedIcon}");
        }

        public void ClickSearchIconStickyElement()
        {
            SearchIconStickyElement.Click();
        }

        public bool VisibleSearchSticky()
        {
            return SearchStickyElement.Displayed;
        }

        public void EnterIntoInputSearch(string input)
        {
            SearchInputStickyElement.Clear();
            SearchInputStickyElement.SendKeys(input);
        }

        public void ClickButtonSearch()
        {
            SearchButtonStickyElement.Click();
        }

        public void ClickScrollDownIcon()
        {
            ButtonScrollElement.Click();
        }

        public bool VisibleStickyMenu()
        {
            return StickyMenuElement.Displayed;
        }
    }
}
