namespace MsStore.Api.Models
{
    public class BasketEntity : EntityBase
    {
        public decimal Amount { set; get; }

        public List<PaymentEntity> Payment { set; get; }
        public List<BasketProduct> BasketProducts { set; get; } 
    }
}
