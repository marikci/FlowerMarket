using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerMarket.Model.Entities
{
    public class StockRoom
    {
        [Key]
        public int StockRoomId { get; set; }
        public string Name { get; set; }
        public IEnumerable<StockRoomStock> StockRoomStocks { get; set; }
    }
}
