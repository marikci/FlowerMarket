using AutoMapper;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.DataAccess.Interfaces;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowerMarket.Business.Managers
{
    public class AccountManager: IAccountManager
    {
        private readonly IConfiguration _config;
        private readonly IRepository<Account> _generalRepository;
        private readonly IMapper _mapper;

        public AccountManager(IConfiguration config, IRepository<Account> generalRepository, IMapper mapper)
        {
            _config = config;
            _generalRepository = generalRepository;
            _mapper = mapper;
        }

        public AccountDto AuthenticateUser(AccountDto loginCredentials)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(loginCredentials.Password);
            bool verified = BCrypt.Net.BCrypt.Verify(loginCredentials.Password, passwordHash);
            var user = _generalRepository.Get(x => x.Email == loginCredentials.Email);
            return BCrypt.Net.BCrypt.Verify(loginCredentials.Password, user.Password) ? _mapper.Map<AccountDto>(user) : null;
        }

        public string GetToken(AccountDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
