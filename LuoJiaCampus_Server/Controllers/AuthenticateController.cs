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
        private readonly ServerDBContext db;
        public AuthenticateController(ServerDBContext context) {
            db = context;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody]User user) {
            User query;
            try {
                query = db.users.FirstOrDefault(
                    o => o.id == user.id
                );
                
            }
            catch (Exception e) {
                return BadRequest(e.InnerException.Message);
            }
            // 验证密码 验证不通过应尝试登录教务系统爬取信息 若无法登录返回错误
            if(query.password != user.password || query.portalpwd != user.portalpwd) {
                return BadRequest("wrong password!");
            }


            var authClaims = new [] {
                // subject 身份
                new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                // jwt id 由Guid.NewGuid()生成一个唯一标识符
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            // 通过启用 IdentityModelEventSource.ShowPII = true 来查看完整的异常信息.
            IdentityModelEventSource.ShowPII = true;
            // 密钥 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1347909588@qq.com"));
            //生成token 需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
            var token = new JwtSecurityToken (
                // issuer代表颁发token的程序
                issuer: "LuoJiaCampus_Server",
                // audience代表受理token的程序
                audience: "LuoJiaCampush_Client",
                // 过期时间
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            
            return Ok(
                new {
                    // 返回token
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    // 返回过期时间
                    expiration = token.ValidTo
                }
            );
        }

    }




}