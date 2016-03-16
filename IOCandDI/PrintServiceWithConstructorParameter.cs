using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCandDI
{
    public class PrintServiceWithConstructorParameter
    {
        public IPrintHelper PrintHelper { get; set; }

        public PrintServiceWithConstructorParameter()
        {
        }

        public PrintServiceWithConstructorParameter(IPrintHelper printHelper)
        {
            this.PrintHelper = printHelper;
        }

        public void Print(string outputStr)
        {
            this.PrintHelper.Print(outputStr);
        }
    }
}
