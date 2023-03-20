using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TokenServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        public IActionResult GetToken()
        {
            var result = CreateToken();
            return Ok(result);
        }

        private LoginResponse CreateToken()
        {
            LoginResponse retVal = new LoginResponse();

            DateTime tokenExpireDate = DateTime.Now.AddMinutes(1);
            var tokenHandler = new JwtSecurityTokenHandler();
            string screetKey = "benbuservisinsecuritykeyiyim";
            var symetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(screetKey));
            var sigInCrediantel = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "JwtTokenServerApplication.com",
                expires: tokenExpireDate,
                signingCredentials: sigInCrediantel
            );

            string token = tokenHandler.WriteToken(jwtSecurityToken); // token yazıyoruz...

            // token objesi dönüyoruz...
            retVal.AccessToken = token;
            retVal.ExpireDate = tokenExpireDate;
            return retVal;
        }
    }
}
