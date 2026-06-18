using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsStore.Api.Contract.Interface;
using MsStore.Api.DTOs.Account;
using MsStore.Api.Filters;
using MsStore.Cache;
using MsStore.Identity;

namespace MsStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IUserRepository _userRepository;
        ICacheService _cacheService;
        public AccountController(IUserRepository userRepository, ICacheService cacheService)
        {
            _userRepository = userRepository;
            _cacheService = cacheService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _userRepository.GetByPhoneNumber(request.PhoneNumber);
            if (user == null)
            {
                user = new Models.UserEntity()
                {
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.PhoneNumber.ToString(),
                };
                await _userRepository.AddAsync(user);
            }

            var token = IdentityUtility.GenerateToken(new TokenParams
            {
                SecurityAlgorithm = "HS256",
                Audience = "",
                Key = "w0jLkeNjV7IKp39hh8iWn7od2/zo1KxWn9jtMzahVfk=",
                Issuer = "",
                UserId = user.Id.ToString(),
                TokenId = Guid.NewGuid().ToString(),
                ExpireTime = TimeSpan.FromMinutes(2),
                Roles = new List<string> { "USER" },
                OtherClaims = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("FULL_NAME","Mohammad Rabiee"),
                },
                Reason = "ON_REGISTER"
            });

            var code = new Random().Next(100000, 999999);
            var key = $"code_{user.Id}";
            await _cacheService.Add(key, code, TimeSpan.FromMinutes(2));


            var result = new RegisterResponse
            {
                Token = token
            };
            return Ok(result);
        }

        [HttpGet]
        [Route("VerifyCode")]
        [CustomAuthorize()]
        public async Task<IActionResult> VerifyCode(string activeCode)
        {
            var userId = "";
            var key =  $"code_{userId}";

            var code=await _cacheService.Get<string>(key);
            if (code != activeCode)
            {
                return Unauthorized();  
            }

            var token = IdentityUtility.GenerateToken(new TokenParams
            {
                SecurityAlgorithm = "HS256",
                Audience = "",
                Key = "w0jLkeNjV7IKp39hh8iWn7od2/zo1KxWn9jtMzahVfk=",
                Issuer = "",
                UserId = userId,
                TokenId = Guid.NewGuid().ToString(),
                ExpireTime = TimeSpan.FromMinutes(30),
                Roles = new List<string> { "USER" },
                OtherClaims = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("FULL_NAME","Mohammad Rabiee"),
                },
                Reason = "ON_VERIFY"
            });

            var result = new RegisterResponse
            {
                Token = token
            };
            return Ok(result);
        }
    }
}
