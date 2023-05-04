using AutoMapper;
using GeekBurger.Products.Contract.Mapper;
using GeekBurger.Products.Controllers;
using GeekBurger.Products.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;

namespace GeekBurguer.Products.UnitTests.Controllers
{
    public class ProductsControllerUnitTests
    {
        private readonly ProductsController _productsController;
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;

        public ProductsControllerUnitTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _mapperMock = new Mock<IMapper>();
            _productsController = new ProductsController(_productServiceMock.Object);
        }

        [Fact]
        public async Task OnGetProductsByStoreName_WhenListIsEmpty_ShouldReturnNotFound()
        {
            //arrange
            var storeName = "Paulista";
            var productList = new List<ProductToGet>();

            _productServiceMock.Setup(p => p.GetProductsByStoreNameAsync(storeName)).ReturnsAsync(productList);
            var expected = new NotFoundResult();

            //act
            var response = await _productsController.GetProductsByStoreName(storeName);

            //assert            
            Assert.IsType<NotFoundResult>(response);
            response.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public async Task OnGetProductsByStoreName_WhenListIsNotEmpty_ShouldReturnResult()
        {
            //arrange
            var storeName = "Paulista";
            var productList = new List<ProductToGet>
            {
                new ProductToGet
                {
                    Image = "",
                    Items = new List<ItemToGet> { new ItemToGet { ItemId = Guid.NewGuid(), Name = "ItemTest" } },
                    Name = "Paulista",
                    Price = 20,
                    ProductId = Guid.NewGuid(),
                    StoreId = Guid.NewGuid()
                }
            };

            _productServiceMock.Setup(p => p.GetProductsByStoreNameAsync(storeName)).ReturnsAsync(productList);

            //act
            var response = await _productsController.GetProductsByStoreName(storeName);

            //assert            
            Assert.IsType<OkObjectResult>(response);
            response.Should().BeOfType<OkObjectResult>();

        }
    }
}