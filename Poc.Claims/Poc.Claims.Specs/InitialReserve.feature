Feature: InitialReserve
	Anything that involves Initial Reserves

Scenario: Set an initial reserve amount because UFG needs to set money aside to payout
	Given an FNOL is ready to be completed
	And the FNOL line liability amount $1000.00 
	When the claim is created from an FNOL
	Then the initial reserve amount is set to $1000.00
