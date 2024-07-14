using damnoshApi.Extensions;
using damnoshApi.Interfaces;
using damnoshApi.Migrations;
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var userName = User.GetUsername();
            var appUser=await _userManager.FindByNameAsync(userName);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if(stock == null) return BadRequest("Stock not found!");

            var userPortfolio = await _portfoRipo.GetUserPortfolio(appUser);

            if(userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower())) return BadRequest("Cannot add same stock to portfolio!");

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppuserId = appUser.Id
            };

            await _portfoRipo.CreateAsync(portfolioModel);
            if(portfolioModel == null)
            {
                return StatusCode(500,"Could not create!");
            }
            else
            {
                return Created();
            }
        }
    
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);

            var userPortfolio = await _portfoRipo.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();

            if(filteredStock.Count() ==1 )
            {
                await _portfoRipo.DeletePOrtfolio(appUser , symbol);
            }
            else
            {
                return BadRequest("Stock not in your portfolio");
            }
            return Ok();
        }
    
    }

}