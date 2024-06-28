Feature: Current Location Label
	I am a user
	I want to click search 
	To be able to see the current location label

Scenario: Current location label showing
	Given I want to consent data usage policy on the main page
	When I want to click the Search field
	Then Check if the current location label is displayed