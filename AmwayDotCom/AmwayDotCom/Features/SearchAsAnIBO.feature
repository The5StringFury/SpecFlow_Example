Feature: SearchAsAnIBO
	Search functions for a IBO is differnt in that more informaiton is displayed such as PVBV

Background: 
Given A user is on amway.com
And A user is logged in as 'amway4511900'


@search IBO
Scenario: Search for product by Name
	
	When The user searches for 'Double X'
	Then the result screen should be displayed
	And PVBV infomation should be available

@search IBO
Scenario: Search for a product by SKU 
	
	When The user searches for 'a4300'
	Then the product page should be displayed
	
	

@search IBO
Scenario: Search for a Miss-spelled product
	
	When The User Searches for 'Douuble X'
	Then the result screen should be displayed
	And the screen should display text indicating these are correctd
	

@search IBO
Scenario: Search for non-existent product
	
	When The user Searches for 'mc bubblious fish eyes'
	Then the result screen should be displayed
	And the result should be no results found
