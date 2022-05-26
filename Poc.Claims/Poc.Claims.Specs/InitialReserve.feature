Feature: InitialReserve
	Anything that involves Initial Reserves


Scenario: Set an initial line reserve amount because UFG needs to set money aside to payout
	Given an FNOL is ready to be completed
	And the FNOL line liability amount is $1000.00 
	When the claim is created from an FNOL
	Then the line initial reserve amount is set to $1000.00

Scenario: Set an initial line reserve amount on a new line on an existing claim because UFG needs to set additional money aside to payout
	Given an existing claim has an initial line reserve amount
	When a new line is added to the claim with an initial reserve amount of $2000.00
	Then the initial reserve amount is set to $2000.00 on the new line

Scenario: The total claim reserve amount is the sum of  the line reserve amounts
	Given an existing claim has an initial line reserve amount of $1000.00
	When a new line is added to the claim with an initial reserve amount of $2000.00
	Then the total reserve amount is set to $3000.00 on the new claim
	
Scenario: Close a single line on a claim that has multiple lines
	Given an exisiting claim that has 5 lines each with a reserve amount of $1000
	When one of the lines is closed
	Then the total reserve amount is $4000 
	And the closed line has a reserve amount of $0 
	And the status of closed
