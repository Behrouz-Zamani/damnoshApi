using damnoshApi.Extensions;
using damnoshApi.Interfaces;
using damnoshApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace damnoshApi.Controllers
{
    [Route("damnoshApi/portfolio")]
    [ApiController]

    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AddUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfoRipo;
        public PortfolioController(UserManager<AddUser> userManager, IStockRepository stockRepository,IPortfolioRepository portfolio)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfoRipo=portfolio;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfoRipo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }

    }
}