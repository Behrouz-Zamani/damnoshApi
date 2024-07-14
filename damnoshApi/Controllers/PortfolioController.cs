using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Interfaces;
using damnoshApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace damnoshApi.Controllers
{
    [Route("damnoshApi/portfolio")]
    [ApiController]

    public class PortfolioController:ControllerBase
    {
        private readonly UserManager<AddUser> _userManager;
        private readonly IStockRepository _stockRepository;
        public PortfolioController(UserManager<AddUser> userManager,IStockRepository stockRepository)
        {
            _userManager=userManager;
            _stockRepository=stockRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            

        }
        
    }
}