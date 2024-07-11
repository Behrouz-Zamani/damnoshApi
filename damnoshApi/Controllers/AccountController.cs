using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using damnoshApi.Dtos.Register;
using damnoshApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace damnoshApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController :ControllerBase
    {
        private readonly UserManager<AddUser> _userManager;
        public AccountController(UserManager<AddUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try{
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var appUser = new AddUser
                {
                    UserName = registerDto.UserName,
                    Email=registerDto.Email
                };
                var result=await _userManager.CreateAsync(appUser , registerDto.Password);
                if(result.Succeeded){
                    var roleResult = await _userManager.AddToRoleAsync(appUser , "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User Created");
                    }
                    else{
                        return StatusCode(500, roleResult.Errors)  ;
                    }
                }
                else
                {
                    return StatusCode(500,result.Errors);
                }
            } catch(Exception e)
            {
                return StatusCode(500,e);
            }
        }
    }
}