using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsStore.Api.Contract.Interface;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Controllers.Admin
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class AdminProductController : ControllerBase
    {
        IProductRepository _productRepository;

        public AdminProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("/CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest model)
        {
            var productEntity = new ProductEntity
            {
                Description = model.Description,
                Title = model.Title,
            };
            await _productRepository.AddAsync(productEntity);
            return Ok();
        }

        [HttpPost]
        [Route("/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }
            product.Description = model.Description;
            product.Title = model.Title;
            await _productRepository.UpdateAsync(product);
            return Ok();
        }

        [HttpPost]
        [Route("/DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(product);
            return Ok();
        }
    }
}
