using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCandDI.Helper.Interface;

namespace IOCandDI
{
    public class ConsoleHelper : IPrintHelper
    {
        /// <summary>
        /// MD5Helper
        /// </summary>
        public IMD5Helper Md5Helper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHelper"/> class.
        /// </summary>
        public ConsoleHelper()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHelper"/> class.
        /// </summary>
        /// <param name="md5Helper">The MD5 helper.</param>
        public ConsoleHelper(IMD5Helper md5Helper)
        {
            this.Md5Helper = md5Helper;
        }

        /// <summary>
        /// Prints the specified output.
        /// </summary>
        /// <param name="output">The output.</param>
        //public void Print(string output)
        //{
        //Console.WriteLine(output);
        //}

        /// <summary>
        /// Prints the specified output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void Print(string output)
        {
            var encryptionStr = this.Md5Helper.Encryption(output);
            Console.WriteLine($"{output} : {encryptionStr}");
        }
    }
}
