using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCandDI
{
    public class FactoryUseReflection
    {
        public static T GetInstance<T>() where T : class, new()
        {
            var instance = Activator.CreateInstance<T>();
            return instance;
        }

        public static T GetInstance<T>(object[] parameter) where T : class, new()
        {
            var instance = Activator.CreateInstance(typeof (T), parameter) as T;
            return instance;
        }
    }
}
