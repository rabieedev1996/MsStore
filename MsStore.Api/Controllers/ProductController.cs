using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("/products")]
        public IActionResult Products([FromBody] ProductsRequest model)
        {
            var result = _productRepository.GetProducts(model);
            return Ok(result);
        }

    }
}
