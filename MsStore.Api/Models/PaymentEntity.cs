namespace MsStore.Api.Models
{
    public class PaymentEntity : EntityBase
    {
        public decimal Amount { set; get; }
        public PaymentStatus Status { set; get; }
        public Guid UserId { set; get; }    
        public Guid BasketId { set; get; }  

        public UserEntity User { set; get; }  
        public BasketEntity Basket { set; get; }
        
    }

    public enum PaymentStatus
    {
        SUCCESS,FAILED,UNKNOWN
    }
}
