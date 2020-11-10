using FlowerMarket.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerMarket.DataAccess
{
    public class FlowerMarketContext:DbContext
    {
        public FlowerMarketContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockRoom> StockRooms { get; set; }
        public DbSet<StockRoomStock> StockRoomStocks { get; set; }
    }
}
