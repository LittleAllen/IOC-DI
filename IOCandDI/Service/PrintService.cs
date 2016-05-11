using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCandDI.Helper.Interface;
using IOCandDI.Service.Interface;

namespace IOCandDI.Service
{
    public class PrintService : IPrintService
    {
        public IPrintHelper PrintHelper { get; set; }

        public PrintService()
        {
        }

        public void Print(string outputStr)
        {
            this.PrintHelper.Print(outputStr);
        }
    }
}
