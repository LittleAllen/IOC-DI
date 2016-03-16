using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IOCandDI.Test
{
    [TestClass]
    public class FactoryIntroduction
    {
        [TestMethod]
        public void PrintSertice()
        {
            var printService = Factory.GetInstance<PrintService>(typeof (PrintService));
            printService.Print("PrintService");

            Assert.AreEqual(typeof(PrintService), printService.GetType());
        }

        [TestMethod]
        public void PrintSerticeConstructorWithParameter()
        {
            var printService = Factory.GetInstance<PrintServiceWithConstructorParameter>(typeof (PrintServiceWithConstructorParameter));
            var consoleHelper = Factory.GetInstance<ConsoleHelper>(typeof (ConsoleHelper));

            printService.PrintHelper = consoleHelper;
            printService.Print("PrintService");

            Assert.AreEqual(typeof(PrintServiceWithConstructorParameter), printService.GetType());
        }

        [TestMethod]
        public void PrintSerticeConstructorWithParameterUseReflectionFactory()
        {
            var consoleHelper = FactoryUseReflection.GetInstance<ConsoleHelper>();
            var printService = FactoryUseReflection.GetInstance<PrintServiceWithConstructorParameter>();

            printService.PrintHelper = consoleHelper;
            printService.Print("PrintService");

            Assert.AreEqual(typeof(PrintServiceWithConstructorParameter), printService.GetType());
        }

        [TestMethod]
        public void PrintSerticeConstructorWithParameterUseReflectionFactoryAndDI()
        {
            var consoleHelper = FactoryUseReflection.GetInstance<ConsoleHelper>();
            var printService = FactoryUseReflection.GetInstance<PrintServiceWithConstructorParameter>(new object[] {consoleHelper});

            printService.Print("PrintService");

            Assert.AreEqual(typeof(PrintServiceWithConstructorParameter), printService.GetType());
        }
    }
}
