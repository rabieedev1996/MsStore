
using System.ComponentModel.DataAnnotations;

namespace MsStore.Api.DTOs
{
    public class ProductsRequest
    {
        public int From { set; get; }   
        public int Count { set; get; }  
        public string Title { set; get; }
    }
    public class ProductsResponse
    {
        public Guid Id { get;  set; }
        public string Title { get;  set; }
    }

    public class CreateProductRequest
    {
        public string Title { set; get; }
        public string Description { set; get; }
    }
    public class UpdateProductRequest
    {
        public Guid Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
    }
}
