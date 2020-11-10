using FlowerMarket.Model.Dtos;

namespace FlowerMarket.Business.Interfaces
{
    public interface IAccountManager
    {
        AccountDto AuthenticateUser(AccountDto loginCredentials);
        string GetToken(AccountDto userInfo);
    }
}
