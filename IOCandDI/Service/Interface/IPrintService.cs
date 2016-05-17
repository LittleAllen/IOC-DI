using IOCandDI.Helper.Interface;

namespace IOCandDI.Service.Interface
{
    public interface IPrintService
    {
        //IPrintHelper PrintHelper { get; set; }
        void Print(string outputStr);
    }
}