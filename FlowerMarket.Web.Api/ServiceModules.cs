using Autofac;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.Business.Managers;
using FlowerMarket.DataAccess.Interfaces;
using FlowerMarket.DataAccess.Repositories;

namespace FlowerMarket.Web.Api
{
    public class ServiceModules: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<StockManager>().As<IStockManager>();
            builder.RegisterType<CartManager>().As<ICartManager>();
            builder.RegisterType<AccountManager>().As<IAccountManager>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        }
    }
}
