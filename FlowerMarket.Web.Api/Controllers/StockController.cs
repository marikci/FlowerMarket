using System.Collections.Generic;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.Model.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FlowerMarket.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockManager _stockManager;
        public StockController(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        [Authorize]
        [HttpGet("{productId}")]
        public IEnumerable<StockRoomStockDto> Get(int productId)
        {
            return _stockManager.GetStockList(productId);
        }
    }
}
