using System;
using Microsoft.AspNetCore.NodeServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace LuoJiaCampus_Server.ToolClasses {
    public class encryptPwd {
        private readonly INodeServices nodeServices;
        public encryptPwd (INodeServices _nodeServices) {
            nodeServices = _nodeServices;
        }
        public async Task<string> encrypt(string pwdToEncrypt) {
            string pwd = await nodeServices.InvokeAsync<string>("./Crawler/encrypt.js", "190034", "dFI6ogbq90PNsNKt");
            Console.WriteLine($"test encrypt password: {pwd}");
            return pwd;
        }
    }


}