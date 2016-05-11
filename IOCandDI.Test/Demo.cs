using System;
using System.Collections.Generic;
using IOCandDI.Helper.Interface;
using IOCandDI.Service;
using IOCandDI.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IOCandDI.Test
{
    [TestClass]
    public class Demo
    {
        [TestMethod]
        public void 直接New()
        {
            PrintService printService = new PrintService();
            printService.Print("直接New");
        }

        [TestMethod]
        public void Interface直接New()
        {
            IPrintService printService = new PrintService();
            printService.Print("Interface直接New");
        }

        [TestMethod]
        public void 工廠模式()
        {
            IPrintService printService = FactoryObj.GetInstance(typeof(PrintService)) as PrintService;
            printService.Print("工廠模式");
        }

        [TestMethod]
        public void 工廠模式加設定屬性()
        {
            IPrintService printService =
                FactoryObj.GetInstance(typeof(PrintService)) as PrintService;
            IPrintHelper printHelper =
                FactoryObj.GetInstance(typeof(ConsoleHelper)) as ConsoleHelper;
            printService.PrintHelper = printHelper;
            printService.Print("工廠模式加設定屬性");
        }

        [TestMethod]
        public void 工廠模式加加建構職參數傳入()
        {
            IPrintHelper printHelper = FactoryObj.GetInstance(typeof(ConsoleHelper)) as ConsoleHelper;
            var objs = new List<object>() { printHelper};
            IPrintService printService = FactoryObj.GetInstance(typeof(PrintService), objs) as PrintService;
            printService.Print("工廠模式加加建構職參數傳入");
        }

        [TestMethod]
        public void 工廠模式加建構式自動掃描參數傳入()
        {
            IPrintService printService = FactoryObj.GetInstanceAutoInjection(typeof(PrintService)) as PrintService;
            printService.Print("工廠模式加建構式自動掃描參數傳入");
        }
    }
}
