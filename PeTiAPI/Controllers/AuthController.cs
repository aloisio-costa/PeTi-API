using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeTiAPI.Dtos.Users;
using PeTiAPI.Helpers;
using PeTiAPI.Models;
using PeTiAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepo _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepo repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO register)
        {
            var user = new User
            {
                Name = register.Name,
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password)
            };

            return Created("success", _repository.Create(user));
        }


        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var user = _repository.GetByEmail(login.Email);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if(!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                SameSite = SameSiteMode.None,
                HttpOnly = true,
                Secure = true, 
                Expires = DateTime.Today.AddDays(1)
            });

            return Ok( new 
            { 
                message="success"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                Guid userId = Guid.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var test = Response.Cookies.ToString();
            Response.Cookies.Delete("jwt");
            

            //foreach (var cookie in HttpContext.Request.Cookies)
            //{
            //    Response.Cookies.Delete(cookie.Key);
            //}
            //if (Request.Cookies["jwt"] != null)
            //{

            //    Response.Cookies.Append("jwt", "jwt", new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddDays(-1d)

            //    });


            //}

            return Ok(new
            {
                message="success "
            });
        }
    }
}
