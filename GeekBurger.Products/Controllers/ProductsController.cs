using AutoMapper;
using GeekBurger.Products.Contract;
using GeekBurger.Products.Contract.Mapper;
using GeekBurger.Products.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurger.Products.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private IProductsRepository _productsRepository;
        private IMapper _mapper;


        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;

        }

        [HttpGet()]
        public IActionResult GetProductsByStoreName([FromQuery] string storeName)
        {
            var productsByStore = _productsRepository.GetProductsByStoreName(storeName).ToList();

            if (productsByStore.Count <= 0)
                return NotFound("Nenhum dado encontrado");

            var productsToGet = _mapper.Map<IEnumerable<ProductToGet>>(productsByStore);

            return Ok(productsToGet);


        }
    }
}
