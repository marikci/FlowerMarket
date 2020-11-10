using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerMarket.Model.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<StockRoomStock> StockRoomStocks { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
    }
}
