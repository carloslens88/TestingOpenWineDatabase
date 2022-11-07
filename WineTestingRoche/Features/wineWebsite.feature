Feature: End to End testing with Open Wine website

Scenario: Check if page loads properly
	Given open wine website
	Then the content must be showed


Scenario Outline: Navigate cross Regions and Wines
	Given open wine website
	When choose region <Region>
	And select wine <Wine>	
	Then the result should be <Expected result>
	And the wine color should be <Color>

Examples:
	| Region      | Wine                   | Expected result        | Color            |
	| "Loire"     | "Philippe de Valois"   | "Philippe de Valois"   | "Rouge"          | 
	| "Champagne" | "Deutz Classique Brut" | "Deutz Classique Brut" | "Effervescent"   |
	| "Bourgogne" | "Domaine La Roche"     | "Domaine La Roche"     | "Blanc"		   |


Scenario Outline: Press like button for specific wine
	Given open wine website
	When choose region <Region>
	And select wine <Wine>	
	And press like button
	Then must be show unlike button

Examples:
	| Region      | Wine                   |
	| "Loire"     | "Philippe de Valois"   |


Scenario Outline: Send comment for specific wine
	Given open wine website
	When choose region <Region>
	And select wine <Wine>	
	And press comment button
	And add some comments <Comment>
	Then comment <Comment> must be show on description area

Examples:
	| Region  | Wine                 | Comment             |
	| "Loire" | "Philippe de Valois" | "This is a comment" |