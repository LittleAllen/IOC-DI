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
        private IPrintHelper _printHelper;

        public PrintService()
        {
        }

        public PrintService(IPrintHelper printHelper)
        {
            this._printHelper = printHelper;
        }

        public void Print(string outputStr)
        {
            this._printHelper.Print(outputStr);
        }
    }
}
