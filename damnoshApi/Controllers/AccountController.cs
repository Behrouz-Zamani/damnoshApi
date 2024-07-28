using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using damnoshApi.Dtos.Register;
using damnoshApi.Interfaces;
using damnoshApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace damnoshApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController :ControllerBase
    {
        private readonly UserManager<AddUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AddUser> _singInManager;
        public AccountController(UserManager<AddUser> userManager,ITokenService tokenService,SignInManager<AddUser> singInManager)
        {
            _userManager = userManager;
            _tokenService=tokenService;
           _singInManager=singInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if(user == null) return Unauthorized("Invalid username !");
            var result = await _singInManager.CheckPasswordSignInAsync(user,loginDto.Password,false);

            if(!result.Succeeded) return Unauthorized("Invalid username or Password not correct");

            return Ok(
                new NewUserDto { UserName = user.UserName, Email = user.Email, Token = _tokenService.CreateToken(user), }
            );

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
                        return Ok(
                            new NewUserDto 
                            {
                                UserName=appUser.UserName,
                                Email=appUser.Email,
                                Token=_tokenService.CreateToken(appUser)
                            }

                        );
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