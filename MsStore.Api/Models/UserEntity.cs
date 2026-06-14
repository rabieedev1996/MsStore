using System.ComponentModel.DataAnnotations;

namespace MsStore.Api.Models
{
    public class UserEntity : EntityBase
    {
        [MaxLength(200)]
        public string FullName { set; get; }
        [MaxLength(200)]
        public string Email { set; get; }
        [MaxLength(1000)]
        public string PasswordHash { set; get; }
        [MaxLength(50)]
        public string UserName { set; get; }
        public long PhoneNumber { set; get; }

        public List<PaymentEntity> Payments { set; get; }
    }
}
