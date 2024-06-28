Feature: Alerts
	I am a user
	I want to handle alert
	To be able to accept is

Scenario: Alert handling
	Given I go to 'JavaScript Alerts' on the Main Page
	When I generate JS alert on the Javascript Alert Page
	And I accpet the alert
	Then Success message is displayed on JavaScript Alert Page