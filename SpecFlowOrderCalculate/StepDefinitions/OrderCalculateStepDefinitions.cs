namespace SpecFlowOrderCalculate
{
    [Binding]
    public class OrderCalculateStepDefinitions
    {
        private double _calculatedTotal;
        private OrderModel _orderRequest;

        private InplaceOrderCalculate _orderÑalculation;

        [Given(@"A group of (.*) people orders (.*) starters, (.*) mains and (.*) drinks, ordered before nineteen is '([^']*)'")]
        [Then(@"A group of (.*) people orders (.*) starters, (.*) mains and (.*) drinks, ordered before nineteen is '([^']*)'")]
        public void GivenAGroupOfPeopleOrdersStartersMainsAndDrinksOrderedBeforeNineteenIs(int people, int starters, int mains, int drinks, Boolean isOrderedBeforeNineteen)
        {
            _orderRequest = new OrderModel
                {
                    ServesCountStarters = starters, 
                    ServesCountMains = mains, 
                    ServesCountDrinks = drinks, 
                    DiscountedDrinks = isOrderedBeforeNineteen 
                };
        }

        [When(@"the order is sent to the endpoint")]
        public void WhenTheOrderIsSentToTheEndpoint()
        {
            _orderÑalculation = new InplaceOrderCalculate();
            _calculatedTotal = _orderÑalculation.Calculate(_orderRequest);
        }

        [When(@"the updated order is sent to the endpoint")]
        public void WhenTheUpdatedOrderIsSentToTheEndpoint()
        {
            if (_calculatedTotal != null)
            {
                var updateCalculatedTotal = _orderÑalculation.Calculate(_orderRequest);
                _calculatedTotal = _calculatedTotal + updateCalculatedTotal;
            }
        }

        [Then(@"the total is calculated correctly in the bill '([^']*)'")]
        public void ThenTheTotalIsCalculatedCorrectlyInTheBill(string actualTotal)
        {
            _calculatedTotal.ToString().Should().Be(actualTotal.ToString(), $"{_calculatedTotal} is not equal {actualTotal}.");
        }
    }
}
