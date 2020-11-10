using System.Collections.Generic;
using AutoMapper;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.DataAccess.Interfaces;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Entities;

namespace FlowerMarket.Business.Managers
{
    public class StockManager : IStockManager
    {
        private readonly IRepository<StockRoomStock> _repository;
        private readonly IMapper _mapper;
        public StockManager(IRepository<StockRoomStock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<StockRoomStockDto> GetStockList(int productId)
        {
            return _mapper.Map<IEnumerable<StockRoomStockDto>>(_repository.Find(x => x.ProductId == productId));
        }
    }
}
