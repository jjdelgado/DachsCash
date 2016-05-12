Feature: Budget
	
@budget
Scenario Outline: Get the correct budget
	Given I ask for a budget with the id <id>
	Then the result should be the correct budget with the correct id <correctId>
	Examples: 
	| id     | correctId |
	| "test" | "test"    |
	| "42"   | "42"      |
