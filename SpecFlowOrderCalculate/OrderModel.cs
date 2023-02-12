namespace SpecFlowOrderCalculate
{
    public class OrderModel
    {
        public const double StartersCost = 4;
        public const double MainsCost = 7;
        public const double DrinksCost = 2.5;
        public const double Discount = 0.3;
        public const double ServiceChanrge = 0.1;
        public bool DiscountedDrinks { get; set; }
        public int ServesCountMains { get; set; }
        public int ServesCountStarters { get; set; }
        public int ServesCountDrinks { get; set; }
    }
}
