using System.Linq;
using AutoMapper;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.DataAccess.Interfaces;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Entities;
using FlowerMarket.Model.Enums;

namespace FlowerMarket.Business.Managers
{
    public class CartManager : ICartManager
    {
        private readonly IRepository<Cart> _saveRepository;
        private readonly IRepository<Cart> _generalRepository;
        private readonly IMapper _mapper;
        private readonly IStockManager _stockManager;


        public CartManager(IRepository<Cart> saveRepository, IRepository<Cart> generalRepository, IStockManager stockManager, IMapper mapper)
        {
            _saveRepository = saveRepository;
            _generalRepository = generalRepository;
            _stockManager = stockManager;
            _mapper = mapper;
        }

        public CartResultEnum UpdateCart(CartDto cart)
        {
            var exists = ExistStock(cart.ProductId, cart.Quantity);
            if (!exists)
            {
                return CartResultEnum.NoStock;
            }

            var cartDatas = _generalRepository.Find(x => x.AccountId == cart.AccountId && x.ProductId == cart.ProductId).FirstOrDefault();
            if (cartDatas != null)
            {
                cartDatas.Quantity = cart.Quantity;
            }
            else
            {
                _saveRepository.Insert(_mapper.Map<Cart>(cart));
            }
            _saveRepository.Update();
            return CartResultEnum.Success;
        }

        private bool ExistStock(int productId, int quantity)
        {
            var stockList = _stockManager.GetStockList(productId);
            return stockList.Sum(x => x.Quantity) >= quantity;
        }
    }
}
