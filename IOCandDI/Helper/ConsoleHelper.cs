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
        /// Initializes a new instance of the <see cref="ConsoleHelper"/> class.
        /// </summary>
        public ConsoleHelper()
        {
        }

        /// <summary>
        /// Prints the specified output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
