Feature: TestHomePage
	Test Openlearn home page

Background: 
	Given I go to Openlearn Home Page

@AC1
Scenario: I can see all items at home page
	Then I can see all items as the attached picture

@AC3
Scenario Outline: Test search
	Given I enter videos into the search input with <xpathSearchInput>
	When I click the search button with <xpathSearchButton>
	Then I see the search results page
Examples: 
	| xpathSearchInput                              | xpathSearchButton                                             |
	| //input[@id='main_search_text_header_sticky'] | //div[@id='main_header']//button[@class='search icon-search'] |
	| //input[@id='banner_search_text']             | //a[@class='search']                                          |

@AC4
Scenario: Test scroll down icon
	When I click scroll down icon
	Then the next section and the sticky menu is showing

@AC5_1
Scenario Outline: Verify links in the sticky menu
	Given I click scroll down icon
	And The sticky menu is showing
	When I click the links in the sticky menu with <xpath>
	Then They work correctly with <url>
Examples: 
	| xpath                                                           | url                                                                                    |
	| //div[@class='pull-left']//a[1]                                 | https://www.open.ac.uk/                                                                |
	| //div[@class='main_sticky']//a[2]                               | https://www.open.edu/openlearn/                                                        |
	| //div[@class='menu_toggle']//a[contains(text(),'Home')]         | https://www.open.edu/openlearn/                                                        |
	| //div[@class='menu_toggle']//a[contains(text(),'Free courses')] | https://www.open.edu/openlearn/free-courses/full-catalogue                             |
	| //div[@class='menu_toggle']//a[contains(text(),'Subjects')]     | https://www.open.edu/openlearn/subject-information                                     |
	| //div[@class='menu_toggle']//a[contains(text(),'For Study')]    | https://www.open.edu/openlearn/for-study                                               |
	| //div[@class='menu_toggle']//a[contains(text(),'For Life')]     | https://www.open.edu/openlearn/for-life                                                |
	| //div[@class='menu_toggle']//a[contains(text(),'Help')]         | https://www.open.edu/openlearn/about-openlearn/frequently-asked-questions-on-openlearn |

@AC5_2
Scenario: Verify search in the sticky menu
	Given I click scroll down icon
	And The sticky menu is showing
	When I click the search icon
	Then The search box is shown
	When I enter videos into the search input
	And I click the search button
	Then I see the search results page


@AC1_2_GetInspired
Scenario Outline: new section get inspired
	Given I go to Openlearn Home Page
	And   I click scroll down icon
	When  The sticky menu is showing
	Then  I check text and click link get inspired <xpath>
	
	

Examples: 
	| xpath                                                              |
	| //a[contains(text(),'Get inspired and learn something new today')] |
	| //img[@alt='Copyright free Icon']                                  |
	| //img[@alt='Copyrighted Icon']                                     |


@AC3_GetInspired_PressIcon
Scenario Outline: Press Icon of all card item
	Given I go to Openlearn Home Page
	And   I click scroll down icon
	When  The sticky menu is showing
	Then  I'll check card item of the home page
	Then  I press the icon of all card item

@AC4_GetInspired