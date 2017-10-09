Feature: Search as a Visitor
	In Order to assist users with finding products
	Search is included on all pages 

@search
Scenario: Search for product by Name
	Given A user is on amway.com
	When The user searches for 'Double X'
	Then the result screen should be displayed

@search
Scenario: Search for a product by SKU 
	Given A user is on amway.com
	When The user searches for 'a4300'
	Then the product page should be displayed

@search
Scenario: Search for a Miss-spelled product
	Given A User is on amway.com
	When The User Searches for 'Douuble X'
	Then the result screen shoiuld be displayed
	And the screen should display text indicating these are correctd

@search
Scenario: Search for non-existent product
	Given A user is on amway.com
	When The user Searches for 'mc bubblious fish eyes'
	Then the result screen should indicate 
