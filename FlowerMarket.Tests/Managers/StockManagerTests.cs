using AutoMapper;
using FlowerMarket.Business.Interfaces;
using FlowerMarket.Business.Managers;
using FlowerMarket.DataAccess.Interfaces;
using FlowerMarket.Model.Dtos;
using FlowerMarket.Model.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FlowerMarket.Tests.Managers
{
    public class StockManagerTests
    {
        private readonly Mock<IRepository<StockRoomStock>> _generalRepositoryMock;
        private readonly IStockManager _stockManager;
        private readonly Mock<IMapper> _mapper;
        public StockManagerTests()
        {
            _generalRepositoryMock = new Mock<IRepository<StockRoomStock>>();
            _mapper= new Mock<IMapper>();
            _stockManager = new StockManager(_generalRepositoryMock.Object, _mapper.Object);
        }

        [Fact]
        public void GetStockList_ShouldReturnSingleStockList_IfStockIsReturnSingleData()
        {
            // Arrange
            var productId = 1;
            var relation = new List<StockRoomStock>() { new StockRoomStock() { ProductId = productId } };
            var relationdto = new List<StockRoomStockDto>() { new StockRoomStockDto() { ProductId = productId } };
            _generalRepositoryMock.Setup(m => m.Find(x => x.ProductId == productId)).Returns(relation);
            _mapper.Setup(m => m.Map<IEnumerable<StockRoomStockDto>>(relation)).Returns(relationdto);

            // Act
            var actual = _stockManager.GetStockList(productId);

            // Assert
            Assert.Single(actual);
            Assert.Equal(productId, actual.FirstOrDefault().ProductId);
        }

        [Fact]
        public void GetStockList_ShouldReturnMultipleStockList_IfStockHasMultipleData()
        {
            // Arrange
            var productId = 1;
            var relation = new List<StockRoomStock>() { new StockRoomStock() { }, new StockRoomStock() { } };
            var relationdto = new List<StockRoomStockDto>() { new StockRoomStockDto() { }, new StockRoomStockDto() { } };
            _generalRepositoryMock.Setup(m => m.Find(x => x.ProductId == productId)).Returns(relation);
            _mapper.Setup(m => m.Map<IEnumerable<StockRoomStockDto>>(relation)).Returns(relationdto);

            // Act
            var actual = _stockManager.GetStockList(productId);

            // Assert
            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void GetStockList_ShouldReturnEmtyStockList_IfStockHasNoData()
        {
            // Arrange
            var productId = 1;
            var realProductId = 2;
            var relation = new List<StockRoomStock>() { new StockRoomStock() { ProductId = productId } };
            var relationdto = new List<StockRoomStockDto>() { new StockRoomStockDto() { ProductId = productId } };
            _generalRepositoryMock.Setup(m => m.Find(x => x.ProductId == realProductId)).Returns(relation);
            _mapper.Setup(m => m.Map<IEnumerable<StockRoomStockDto>>(relation)).Returns(relationdto);

            // Act
            var actual = _stockManager.GetStockList(productId);

            // Assert
            Assert.Empty(actual);
        }
    }
}
