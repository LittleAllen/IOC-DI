using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IOCandDI.Helper.Interface;

namespace IOCandDI
{
    /// <summary>
    /// MD5Helper
    /// </summary>
    /// <seealso cref="IOCandDI.Helper.Interface.IMD5Helper" />
    public class MD5Helper : IMD5Helper
    {
        /// <summary>
        /// Encryptions the specified source string.
        /// </summary>
        /// <param name="sourceStr">The source string.</param>
        /// <returns></returns>
        public string Encryption(string sourceStr)
        {
            MD5 md5 = MD5.Create();//建立一個MD5
            byte[] source = Encoding.Default.GetBytes(sourceStr);//將字串轉為Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            return result;
        }

    }
}
