namespace MsStore.Api.Models
{
    public class BasketProduct : EntityBase
    {
        public Guid ProductId { set; get; }
        public Guid BasketId { set; get; }

        public ProductEntity Product { set; get; }
        public BasketEntity Basket { set; get; }

    }
}
