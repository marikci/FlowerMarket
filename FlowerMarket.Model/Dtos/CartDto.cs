namespace FlowerMarket.Model.Dtos
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public int Quantity { get; set; }
    }
}
