using System;
using Jose;
using System.Text;

namespace LuoJiaCampus_Server.ToolClasses {
    public class DecodeJwt {
        public static string decode(string tokenToDecode) {
            
            Console.WriteLine(tokenToDecode);
            string token = Jose.JWT.Decode(
                tokenToDecode,
                Encoding.UTF8.GetBytes("1347909588@qq.com"),
                JweAlgorithm.PBES2_HS256_A128KW,
                JweEncryption.A128CBC_HS256,
                null
            );
            Console.WriteLine(token);
            return token;
        }
    }
}