using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon.Services;
using BopodaMVP.Data;
using BopodaMVP.Models.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BopodaMVP.Controllers
{
    [LimitPerMin]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceLocation _serviceLocation;
        private readonly MVPDbContext _dbContext;
        private const int _defaultSize = 30 * 1024 * 1024;

        public HomeController(
            IConfiguration configuration,
            ServiceLocation serviceLocation,
            MVPDbContext dbContext)
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
