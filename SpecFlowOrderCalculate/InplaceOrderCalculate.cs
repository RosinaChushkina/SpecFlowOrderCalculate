namespace SpecFlowOrderCalculate
{
    public class InplaceOrderCalculate : IOrderCalculator
    {
        public double Calculate(OrderModel order)
        {
            var totalFood = OrderModel.StartersCost * order.ServesCountStarters + OrderModel.MainsCost * order.ServesCountMains;
            totalFood += totalFood * OrderModel.ServiceChanrge;
           
            var totalDrinks = OrderModel.DrinksCost * order.ServesCountDrinks;
            if (order.DiscountedDrinks)
            {
                totalDrinks -= totalDrinks * OrderModel.Discount;
            }

            return totalFood + totalDrinks;
        }
    }
}
