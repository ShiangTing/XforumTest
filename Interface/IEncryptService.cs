using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IEncryptService
    {
        /// <summary>
        /// MD5 Encryption
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        string ToMD5(string source);
    }
}
