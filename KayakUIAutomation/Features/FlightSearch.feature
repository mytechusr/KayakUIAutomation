Feature: Flight Search
	Search Flights for booking


Background: Pre-Condition
	Given User navigates to Search Page

Scenario Outline: User is able to search flights with scenario outline
	When User enters "<Source>", "<Destination>", "<FromDate>" and "<ToDate>"
	And User clicks on Search button
	Then Search Results should be displayed
	When User clicks on View Deal button
	Then Flight details should be displayed
	Examples:
	| Source    | Destination | FromDate  | ToDate    |
	| New Delhi | Mumbai      | Wed 10/11 | Wed 17/11 |

Scenario: User gets message that airpot is empty
	When User does not enter Destination
	And User clicks on Search button
	Then User gets error message that airport is empty
