using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LuoJiaCampus_Server.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Authorization;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    // [Authorize]
    [Route("Authenticate/")]
    public class AuthenticateController: ControllerBase {
        public AuthenticateController() {

        }

        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody]User user) {
            var authClaims = new [] {
                new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            // 通过启用 IdentityModelEventSource.ShowPII = true 来查看完整的异常信息.
            IdentityModelEventSource.ShowPII = true;
            // 密钥 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456"));
            //生成token 需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
            var token = new JwtSecurityToken (
                issuer: "thomas",
                audience: "thomas",
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            
            return Ok(
                new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
            );
        }

    }




}