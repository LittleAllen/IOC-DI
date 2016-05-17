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
        private IEncryHelper _md5Helper;
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHelper"/> class.
        /// </summary>
        public ConsoleHelper()
        {
        }

        public ConsoleHelper(IEncryHelper md5Helper)
        {
            this._md5Helper = md5Helper;
        }

        /// <summary>
        /// Prints the specified output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void Print(string output)
        {
            var encryStr = this._md5Helper.Encryption(output);
            Console.WriteLine($"{output}:{encryStr}");
        }
    }
}
