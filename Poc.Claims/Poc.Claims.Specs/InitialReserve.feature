Feature: InitialReserve
	Anything that involves Initial Reserves


Scenario: Set an initial line reserve amount because UFG needs to set money aside to payout
	Given an FNOL is ready to be completed
	And the FNOL line liability amount $1000.00 
	When the claim is created from an FNOL
	Then the line initial reserve amount is set to $1000.00

Scenario: Set an initial line reserve amount on a new line on an existing claim because UFG needs to set additional money aside to payout
	Given an existing claim has an initial line reserve amount
	And we are specifying a new line that has an initial reserve amount $2000.00 
	When the new line is added to the claim
	Then the initial reserve amount is set to $2000.00 on the new line