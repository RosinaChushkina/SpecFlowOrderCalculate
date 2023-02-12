Feature: OrderCalculate
as a user
I want to order the food from the restaurant,
so that I am able to order the starters, mains, and drinks, and the system total is calculated correctly in the bill, and add a 10% service charge on food.

@tiketNumber1
Scenario: 1 A new endpoint can calculate the total of the order, and add a 10% service charge on food.
	Given A group of 4 people orders 4 starters, 4 mains and 4 drinks, ordered before nineteen is 'False' 
	When the order is sent to the endpoint
	Then the total is calculated correctly in the bill '58.4'


	@tiketNumber2
	Scenario: 2 A new endpoint can calculate the total of the order, and add 30% discount when ordered before 19:00.
	Given A group of 2 people orders 1 starters, 2 mains and 2 drinks, ordered before nineteen is 'True' 
	When the order is sent to the endpoint
	Then the total is calculated correctly in the bill '23.3'
	And A group of 2 people orders 0 starters, 2 mains and 2 drinks, ordered before nineteen is 'False' 
	When the updated order is sent to the endpoint
	Then the total is calculated correctly in the bill '43.7'

	@tiketNumber2
Scenario: 3 A new endpoint can calculate the total correctly in the final bill, when the updated order is sent to the endpoint 
	Given A group of 4 people orders 4 starters, 4 mains and 4 drinks, ordered before nineteen is 'False' 
	When the order is sent to the endpoint
	Then the total is calculated correctly in the bill '58.4'
	And A group of 3 people orders 3 starters, 3 mains and 3 drinks, ordered before nineteen is 'False' 
	When the order is sent to the endpoint
	Then the total is calculated correctly in the bill '43.8'
