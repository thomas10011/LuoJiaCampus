using System.Data.Common;
using System.Text;
using System.Security.Claims;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LuoJiaCampus_Server.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.NodeServices;
using LuoJiaCampus_Server.Crawler;
using System.Threading.Tasks;
using LuoJiaCampus_Server.ToolClasses;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    // [Authorize]
    [Route("Authenticate/")]
    public class AuthenticateController: ControllerBase {
        private readonly ServerDBContext db;
        private readonly INodeServices nodeServices;
        public AuthenticateController(ServerDBContext context, INodeServices _nodeServices) {
            db = context;
            nodeServices = _nodeServices;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody]User user) {
            User query;
            // 首先尝试从数据库读取用户信息
            try {
                query = db.users.FirstOrDefault(
                    o => o.id == user.id
                );
                
            }
            catch (Exception e) {
                return BadRequest(e.InnerException.Message);
            }
            // 查询不到用户或者密码验证不通过应尝试登录信息门户 若无法登录返回错误
            if(query == null || query.password != user.password || query.portalpwd != user.portalpwd)
            
             {
                JwCrawler.initAttributes();
                bool result = JwCrawler.login(user.id, getPwdEncrypted(user.portalpwd, JwCrawler.dynamicPwdEncryptSalt).Result);

                if (!result)
                    return BadRequest("wrong password!");

                // 信息门户登录成功的话，爬下来个人信息保存到数据库
                JwCrawler.loginJw();    // 登录教务
                User newUser = StudentInfoCrawler.crawlStudentInfo();   // 爬取个人信息
                newUser.password = user.password;
                newUser.portalpwd = user.portalpwd;
                if (query == null)
                    db.users.Add(newUser);
                else
                    db.users.Update(newUser);

                db.SaveChanges();

                // 退出登录
                JwCrawler.logout();
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

        public async Task<string> getPwdEncrypted(string pwdToEncrypt, string salt) {
            Console.WriteLine("try encrypt");
            Console.WriteLine("js Location: " + Constants.encryptJsRoute);
            string pwd = nodeServices.InvokeAsync<string>(Constants.encryptJsRoute, pwdToEncrypt, salt).Result;
            Console.WriteLine($"encrypted password: {pwd}");
            return pwd;
        }

    }




}