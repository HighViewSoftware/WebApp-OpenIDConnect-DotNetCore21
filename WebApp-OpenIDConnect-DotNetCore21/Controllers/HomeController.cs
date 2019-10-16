using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApp_OpenIDConnect_DotNetCore21.Data;
using WebApp_OpenIDConnect_DotNetCore21.Models.HomeViewModels;

namespace WebApp_OpenIDConnect_DotNetCore21.Controllers
{
    [LimitPerMin]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceLocation _serviceLocation;
        private readonly ColossusDbContext _dbContext;
        private const int _defaultSize = 30 * 1024 * 1024;

        public HomeController(
            IConfiguration configuration,
            ServiceLocation serviceLocation,
            ColossusDbContext dbContext)
        {
            _configuration = configuration;
            _serviceLocation = serviceLocation;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                MaxSize = _defaultSize
            };
            return View(model);
        }

        [Route("Account/Signout")]
        public IActionResult SignOut()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
