using AutoMapper;
using CBBStoreAPI.Data.Products;
using CBBStoreAPI.VM.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        #region fields
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        #endregion

        #region implementation

        //GET /products
        [HttpGet]
        public ActionResult<IEnumerable<ProductsVM>> GetAllProducts(string productName)
        {
            var products = _productsRepository.GetAllProducts(productName);

            if (products.Any())
            {
                return Ok(_mapper.Map<IEnumerable<ProductsVM>>(products));
            }
            return StatusCode(204, new { message = "No products found."});
        }

        //GET /products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductsVM> GetProductById(int id)
        {
            var product = _productsRepository.GetProductById(id);
            
            if(product != null)
            {
                return Ok(_mapper.Map<ProductsVM>(product));
            }
            return StatusCode(204, new { message = "Product does not exist."});
        }

        //POST /products
        [HttpPost]
        public ActionResult CreateProduct(ProductsCreateVM model)
        {
            if (ModelState.IsValid)
            {
                _productsRepository.CreateProduct(_mapper.Map<Models.Products>(model));
                return StatusCode(201, "Product has been successfully created.");
            }

            return StatusCode(400, new { message = "There was an error while creating product."});
        }

        //PUT /products/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(ProductsUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                _productsRepository.UpdateProduct(_mapper.Map<Models.Products>(model));
                return StatusCode(200, new { message = "Product has been successfully updated."});
            }
            return BadRequest(model);
        }

        //DELETE /products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _productsRepository.GetProductById(id);

            if(product != null)
            {
                _productsRepository.DeleteProduct(product);
                return StatusCode(200, new { message = "Product has been deleted."});
            }

            return StatusCode(404, new { message = "Product does not exist." });
        }
        #endregion
    }
}
