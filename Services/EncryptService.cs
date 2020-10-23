using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XforumTest.Interface;

namespace XforumTest.Services
{
    public class EncryptService : IEncryptService
    {
        /// <summary>
        /// MD5 Encryption
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string ToMD5(string source)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(source);//將要加密的字串轉換為位元組陣列
            byte[] encryptdata = md5.ComputeHash(bytes);//將字串加密後也轉換為字元陣列
            return Convert.ToBase64String(encryptdata);//將加密後的位元組陣列轉換為加密字串
        }
    }
}
