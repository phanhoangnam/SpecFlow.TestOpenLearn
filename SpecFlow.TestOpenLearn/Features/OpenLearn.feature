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
	When I click  banner search button with <xpathSearchButton>
	Then I see the search results page
Examples: 
	| xpathSearchInput                              | xpathSearchButton                                             |
	| //input[@id='main_search_text_header_sticky'] | //div[@id='main_header']//button[@class='search icon-search'] |
	| //input[@id='banner_search_text']             | //a[@class='search']                                          |