using System.ComponentModel.DataAnnotations;

namespace FlowerMarket.Model.Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Account Account { get; set; }
    }
}
