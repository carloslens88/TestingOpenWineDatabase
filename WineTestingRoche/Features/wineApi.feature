Feature: API Testing Open Wine Database

Scenario: Fetch all comments
    Given Wine Open Database API
    When I make a get request to /comments
    Then the response status code is 200
    And the response data should be the number of comments

Scenario: Fetch all likes
    Given Wine Open Database API
    When I make a get request to /likes
    Then the response status code is 200
    And the response data should be the number of likes

Scenario: Fetch all regions
    Given Wine Open Database API
    When I make a get request to /regions
    Then the response status code is 200
    And the response data should contains all regions list

Scenario Outline: Fetch wine by id
    Given Wine Open Database API
    When I make a get request to /wines with <WineId>
    Then the response status code is 200
    And the response data should contains all wine information

Examples:
	| WineId                     | 
	| "cheval-noir"              |
    | "les-champs-clos-rouge"    |

Scenario Outline: Fetch wine by wrong id
    Given Wine Open Database API
    When I make a get request to /wines with <WineId>
    Then the response status code is 404

Examples:
	| WineId                     | 
	| "wrong-wine-id"            |

Scenario Outline: Fetch wines by region
    Given Wine Open Database API
    When I make a get request to /wines?region with <Region>
    Then the response status code is 200
    And the response data should contains all wine information

Examples:
	| Region        |
	| "Loire"       |
	| "Bourdeaux"   |