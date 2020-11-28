using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public string Get()
        {
            return "Olá";
        }
    }
}