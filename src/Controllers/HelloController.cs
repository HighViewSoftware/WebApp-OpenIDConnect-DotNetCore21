using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BopodaMVP.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            var id = User.Claims.SingleOrDefault(t => t.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            return Json(new { Id = id });
        }
    }
}
