using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuperHeros.Configuration;
using SuperHeros.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SuperHeros.Controllers
{
    [ApiController]
    [Route("Authentication")]
    //[ApiExplorerSettings(GroupName = "v1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration) => _configuration = configuration;

        private User AuthenticateUser(User user)
        {
            User _user = null;

            if (user.UserName.Equals("shashiPhi") && user.Password.Equals("shashi@12"))
            {
                _user = new User { UserName = "Shashi Kumar" };
            }
            return _user;
        }

        private string GenrateToken(User user)
        {
            var jwtConfiguration = new JwtConfiguration();
            _configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwtConfiguration.ValidIssuer, jwtConfiguration.ValidAudience, null,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtConfiguration.Expires)), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken(User user)
        {
            IActionResult response = Unauthorized();
            var _user = AuthenticateUser(user);

            if (_user != null)
            {
                var token = GenrateToken(_user);
                response = Ok(new { Token = token, User = _user.UserName });
            }

            return response;
        }
    }
}
