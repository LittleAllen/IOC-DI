using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCandDI
{
    public class Factory
    {
        public static T GetInstance<T>(Type type) where T : class ,new()
        {
            var typeName = type.Name;
            switch (typeName)
            {
                case "PrintService":
                    var printService = new PrintService() as T;
                    return printService;

                case "PrintServiceWithConstructorParameter":
                    var printServiceWithConstructorParameter = new PrintServiceWithConstructorParameter() as T;
                    return printServiceWithConstructorParameter;

                case "ConsoleHelper":
                    var consoleHelper = new ConsoleHelper() as T;
                    return consoleHelper;

                default:
                    return null;
            }
        }
    }
}
