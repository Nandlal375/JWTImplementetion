using JWTImplementetion.Interfaces;
using JWTImplementetion.Model;
using JWTImplementetion.RequestModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTImplementetion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
                _authService = authService;
        }
        

        // POST api/<AuthController>
        [HttpPost]
        public string Post([FromBody] LoginRequest loginRequest)
        {
            return _authService.Login(loginRequest);
        }

        // PUT api/<AuthController>/5
        [HttpPost("AddUser")]
        
        public User AddUser(int id, [FromBody] User user)
        {
            return _authService.AddUser(user);
        }
    }
}
