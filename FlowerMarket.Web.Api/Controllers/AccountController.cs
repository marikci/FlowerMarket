using FlowerMarket.Business.Interfaces;
using FlowerMarket.Model.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlowerMarket.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAccountManager _accountManager;
        public AccountController(IConfiguration config, IAccountManager accountManager)
        {
            _config = config;
            _accountManager = accountManager;
        }
        

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AccountDto login)
        {
            IActionResult response = Unauthorized();
            var user = _accountManager.AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = _accountManager.GetToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user.Email,
                });
            }

            return response;
        }
    }
}
