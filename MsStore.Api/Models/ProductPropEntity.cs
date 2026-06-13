using System.ComponentModel.DataAnnotations;

namespace MsStore.Api.Models
{
    public class ProductPropEntity:EntityBase
    {
        [MaxLength(50)]
        public string Title { set; get; }
        [MaxLength(50)]
        public string Value { set; get; }
        public Guid ProductId { set; get; } 
        public ProductEntity Product { set; get; }   
        
    }
}
