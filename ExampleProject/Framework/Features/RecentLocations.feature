Feature: Recent Location
	I am a user
	I want to search city
	I want to go back to main page
	I want to select the first recent Location
	To be able to see the first recent Location

Scenario: Using the recent location
	Given I want to consent data usage policy on the main page
	When I Input 'London' in the search field
	And I Click on the first Search result
	And Go back to the Main page
	And Choose the first city in Recent locations
	And Handle the Ad frame
	Then Check if the City weather page header contains 'London' from the Search