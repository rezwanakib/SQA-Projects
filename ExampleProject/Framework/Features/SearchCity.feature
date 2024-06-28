Feature: Search 
	I am a user
	I want to search city
	To be able to see the searched city
	P.S. : The Accuweather 1st search result for "New York" gives a singapore based result thus failing the test. So, I used "Dhaka" instead of "New York"

Scenario: Search the City Name
	Given I want to consent data usage policy on the main page
	When I Input 'Dhaka' in the search field
	And I Click on the first search result
	Then Check if the City weather page header contains 'Dhaka' from the search