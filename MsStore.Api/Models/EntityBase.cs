namespace MsStore.Api.Models
{
    public class EntityBase
    {
        public Guid Id { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime? ModifyDate { set; get; }
        public long NumericCreateAtFa { set; get; }
        public bool IsDeleted { get;  set; }
    }
}
