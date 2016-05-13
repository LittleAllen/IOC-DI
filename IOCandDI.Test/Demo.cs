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
            //printService.Print("直接New");
        }

        [TestMethod]
        public void Interface直接New()
        {
            //printService.Print("Interface直接New");
        }

        [TestMethod]
        public void 工廠模式()
        {
            //printService.Print("工廠模式");
        }

        [TestMethod]
        public void 工廠模式加設定屬性()
        {
            //printService.Print("工廠模式加設定屬性");
        }

        [TestMethod]
        public void 工廠模式加加建構職參數傳入()
        {
            //printService.Print("工廠模式加加建構職參數傳入");
        }

        [TestMethod]
        public void 工廠模式加建構式自動掃描參數傳入()
        {
            //printService.Print("工廠模式加建構式自動掃描參數傳入");
        }
    }
}
