using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        SQLContext _sQLContext;
        public ProductController(SQLContext sQLContext)
        {
            _sQLContext = sQLContext;
        }


        [HttpPost]
        [Route("/products")]
        public IActionResult Products([FromBody] ProductsRequest model)
        {
            //var products = _sQLContext.Products.Include(a => a.ProductProps).ToList();
            //var products = _sQLContext.Products.Where(a=>a.Title.Contains("Samsung")).ToList();
            //var products1 = _sQLContext.Products.ToList().Where(a => a.Title.Contains("Samsung"));

            var productsQuery = _sQLContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(model.Title))
            {
                productsQuery = productsQuery.Where(a => a.Title.Contains(model.Title));
            }
            var products = productsQuery.OrderByDescending(a => a.CreatedAt).Skip(model.From).Take(model.Count).ToList();

            //var result = new List<ProductsResponse>();

            //foreach (var product in products) {
            //    result.Add(new ProductsResponse
            //    {
            //        Id=product.Id,
            //        Title=product.Title,
            //    });
            //}

            var result = products.Select(a => new ProductsResponse
            {
                Id = a.Id,
                Title = a.Title,
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        [Route("/CreateProduct")]
        public IActionResult CreateProduct([FromBody] CreateProductRequest model)
        {
            var productEntity = new ProductEntity
            {
                Description = model.Description,
                Title = model.Title,
            };
            
            _sQLContext.Add(productEntity);
            _sQLContext.SaveChanges();  
            return Ok();
        }

        [HttpPost]
        [Route("/UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequest model)
        {
            var product = _sQLContext.Products.AsNoTracking().FirstOrDefault(a => a.Id == model.Id);

            //_sQLContext.Products.Update(product);
            //_sQLContext.SaveChanges();
            //_sQLContext.ChangeTracker.Clear();
            //_sQLContext.Entry(product).Reload();
            //var product1 = _sQLContext.Products.AsNoTracking().FirstOrDefault(a => a.Id == model.Id);
            //_sQLContext.Products.Update(product1);
            //_sQLContext.SaveChanges();
            //_sQLContext.ChangeTracker.Clear();

            if (product == null)
            {
                return NotFound();
            }
            product.Description = model.Description;
            product.Title = model.Title;
            _sQLContext.Products.Update(product);
            _sQLContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/DeleteProduct")]
        public IActionResult DeleteProduct([FromBody] DeleteProductRequest model)
        {
            var product = _sQLContext.Products.AsNoTracking().FirstOrDefault(a => a.Id == model.Id);
            if (product == null)
            {
                return NotFound();
            }
            _sQLContext.Products.Remove(product);
            _sQLContext.SaveChanges();
            return Ok();
        }
        
    }
}
