using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCandDI
{
    public class ConsoleHelper : IPrintHelper
    {
        public void Print(string output)
        {
            Console.WriteLine("I am consolehelper method");
        }
    }
}
