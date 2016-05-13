using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCandDI.Helper.Interface;
using IOCandDI.Service.Interface;

namespace IOCandDI.Service
{
    /// <summary>
    /// PrintService
    /// </summary>
    public class PrintService : IPrintService
    {
        public PrintService()
        {
        }

        public void Print(string outputStr)
        {
            Console.WriteLine(outputStr);
        }
    }
}
