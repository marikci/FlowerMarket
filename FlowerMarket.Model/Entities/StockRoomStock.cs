using System.ComponentModel.DataAnnotations;

namespace FlowerMarket.Model.Entities
{
    public class StockRoomStock
    {
        [Key]
        public int StockRoomStockId { get; set; }
        public int StockRoomId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual StockRoom StockRoom { get; set;}
        public virtual Product Products { get; set;}
    }
}
