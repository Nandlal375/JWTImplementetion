using JWTImplementetion.Context;
using JWTImplementetion.Interfaces;
using JWTImplementetion.Model;
using JWTImplementetion.RequestModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTImplementetion.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _jwtContext; 
        private readonly IConfiguration _configuration;
        public AuthService(JwtContext jwtContext, IConfiguration configuration)
        {
                _jwtContext = jwtContext;
                _configuration = configuration;
        }
        public User AddUser(User user)
        {
           var result = _jwtContext.users.Add(user);
            _jwtContext.SaveChanges();
            return result.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.Username != null && loginRequest.Password != null)
            {
                var result = _jwtContext.users.SingleOrDefault(x => x.email == loginRequest.Username && x.password == loginRequest.Password);
                if (result != null)
                {
                    var claims = new[]
                    {
                   new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                   new Claim("Id", result.Id.ToString()),
                   new Claim("Username", result.name),
                   new Claim("Email", result.email)
                 };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {

                    throw new Exception("user is not valid");
                }
            }
            else
            {
                throw new Exception("credentials are not valid");
            }
        }
    }
}
