using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebApp_OpenIDConnect_DotNetCore21.Data;
using WebApp_OpenIDConnect_DotNetCore21.Models;
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
            var user = GetCurrentUserAsync();
            var model = new IndexViewModel
            {
                MaxSize = _defaultSize
            };
            return View(model);
        }

        private async Task<ColossusUser> GetCurrentUserAsync()
        {
            var id = User.Claims.SingleOrDefault(t => t.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var user = await _dbContext.Users.SingleOrDefaultAsync(t => t.Id == id);
            if (user == null)
            {
                var newUser = new ColossusUser
                {
                    Id = id,
                    SiteName = string.Empty
                };
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
            }
            return user;
        }
    }
}
