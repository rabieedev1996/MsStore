namespace MsStore.Api.DTOs.Account
{
   public class RegisterRequest
    {
        public long PhoneNumber { set; get; }
    }
    public class RegisterResponse
    {
        public string Token { set; get; }
    }
}
