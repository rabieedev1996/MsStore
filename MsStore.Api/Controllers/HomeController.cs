using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MsStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
    }

    public class PostApiRequest
    {
        public string Field1 { set; get; }
        public int Field2 { set; get; }
    }
}
