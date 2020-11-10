using AutoMapper;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.Business.Managers;
using FlowerMarket.DataAccess.Interfaces;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Entities;
using FlowerMarket.Model.Enums;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace FlowerMarket.Tests.Managers
{
    public class CartManagerTests
    {
        private readonly Mock<IRepository<Cart>> _generalRepositoryMock;
        private readonly Mock<IRepository<Cart>> _saveRepositoryMock;
        private readonly Mock<IStockManager> _stockManagerMock;
        private readonly ICartManager _cartManager;
        private readonly Mock<IMapper> _mapper;
        public CartManagerTests()
        {
            _generalRepositoryMock = new Mock<IRepository<Cart>>();
            _saveRepositoryMock = new Mock<IRepository<Cart>>();
            _stockManagerMock = new Mock<IStockManager>();
            _mapper = new Mock<IMapper>();
            _cartManager = new CartManager(_saveRepositoryMock.Object, _generalRepositoryMock.Object, _stockManagerMock.Object, _mapper.Object);
        }

        [Fact]
        public void UpdateCart_ShouldReturnSuccess_IfCartCreate()
        {
            // Arrange
            var productId = 1;
            var cartId = 2;
            var quantity = 5;
            var relationdto = new List<StockRoomStockDto>() { new StockRoomStockDto() { ProductId = productId } };
            var carList = new List<Cart>() { new Cart() { ProductId = productId, CartId = cartId, Quantity = quantity } };

            _stockManagerMock.Setup(m => m.GetStockList(productId)).Returns(relationdto);
            _generalRepositoryMock.Setup(m => m.Find(x => x.ProductId == productId)).Returns(carList);
            _saveRepositoryMock.Setup(m => m.Update());
            // Act
            var actual = _cartManager.UpdateCart(new CartDto());

            // Assert
            Assert.Equal(CartResultEnum.Success, actual);
        }

        [Fact]
        public void UpdateCart_ShouldReturnSuccess_IfCartUpdate()
        {
            // Arrange
            var productId = 1;
            var accountId = 1;
            var realQuantity = 20;
            var quantity = 12;
            var cartId = 2;
            var relationDto = new List<StockRoomStockDto>()
                {new StockRoomStockDto() {ProductId = productId, Quantity = realQuantity}};
            _stockManagerMock.Setup(m => m.GetStockList(productId)).Returns(relationDto);
            _generalRepositoryMock.Setup(m => m.Find(x => x.ProductId == productId && x.AccountId == accountId))
                .Returns(new List<Cart>() {new Cart() {AccountId = accountId, ProductId = productId}});
            _saveRepositoryMock.Setup(m => m.Insert(new Cart() { ProductId = productId, CartId = cartId }));
            _saveRepositoryMock.Setup(m => m.Update());
           
            // Act
            var actual = _cartManager.UpdateCart(new CartDto() { ProductId = productId,AccountId=accountId ,Quantity = quantity,CartId=cartId });

            // Assert
            Assert.Equal(CartResultEnum.Success, actual);
        }


        [Fact]
        public void UpdateCart_ShouldReturnNoStock_IfNoStock()
        {
            // Arrange
            var productId = 1;
            var cartId = 2;
            var realQuantity = 5;
            var quantity = 5;
            var carList = new List<Cart>() { new Cart() { ProductId = productId, CartId = cartId, Quantity = realQuantity } };

            _stockManagerMock.Setup(m => m.GetStockList(productId)).Returns(new List<StockRoomStockDto>());
            _generalRepositoryMock.Setup(m => m.Find(x => x.ProductId == productId)).Returns(carList);
            _saveRepositoryMock.Setup(m => m.Update());
            // Act
            var actual = _cartManager.UpdateCart(new CartDto() { Quantity = quantity});

            // Assert
            Assert.Equal(CartResultEnum.NoStock, actual);
        }
    }
}
