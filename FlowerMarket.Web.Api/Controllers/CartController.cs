using FlowerMarket.Business.Interfaces;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FlowerMarket.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [Authorize]
        [HttpPost]
        public CartResultEnum Post([FromBody] CartDto value)
        {
            return _cartManager.UpdateCart(value);
        }
    }
}
