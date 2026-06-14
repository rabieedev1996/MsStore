using System.ComponentModel.DataAnnotations;

namespace MsStore.Api.Models
{
    public class ProductEntity : EntityBase
    {
        [MaxLength(50)]
        public string Title { set; get; }
        [MaxLength(50)]
        public string Description { set; get; }
        //public string PropertiesJson { set; get; }
        public List<ProductPropEntity> ProductProps { set; get; }
    }


}
