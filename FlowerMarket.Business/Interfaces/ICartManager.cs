using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Enums;

namespace FlowerMarket.Business.Interfaces
{
    public interface ICartManager
    {
        CartResultEnum UpdateCart(CartDto cart);
    }
}
