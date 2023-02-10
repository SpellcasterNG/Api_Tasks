using Api_TareasSP.Dtos;
using Api_TareasSP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TareasSP_DB;

namespace Api_TareasSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService JwtService;
        private readonly TasksSPContext _Context; 


        public UserController(IJwtService jwtService, TasksSPContext _Context)
        {
            this.JwtService = jwtService;
            this._Context = _Context;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginDTO user)
        {
            if (!string.IsNullOrEmpty(user.ToString()))
            {
                var usuario = _Context.Users.FirstOrDefault(x => x.Email== user.Email && x.Password == user.Password);
                return Ok(JwtService.BuildToken(usuario));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
