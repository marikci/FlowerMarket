using System.Collections.Generic;
using FlowerMarket.Model.Dtos;

namespace FlowerMarket.Business.Interfaces
{
    public interface IStockManager
    {
        IEnumerable<StockRoomStockDto> GetStockList(int productId);
    }
}
