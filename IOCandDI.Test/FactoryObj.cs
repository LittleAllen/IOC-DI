using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IOCandDI.Test
{
    public class FactoryObj
    {
        private static List<Assembly> _assemblies;

        public static object GetInstance(Type type)
        {
            var instance = Activator.CreateInstance(type);
            return instance;
        }

        public static object GetInstance(Type type, List<object> parameters)
        {
            var instance = Activator.CreateInstance(type, parameters.ToArray());
            return instance;
        }

        public static object GetInstanceAutoInjection(Type type)
        {
            LoadAssembly();

            var realInstanceType =
                _assemblies.Select(p => p.ExportedTypes.First(t => t.IsInterface == false && type.IsAssignableFrom(t)))
                    .First();
            var constructorInfos = realInstanceType.GetConstructors();
            var constructorInfo = constructorInfos.First(p => p.GetParameters().Count() > 0);
            if (constructorInfo != null)
            {
                var paramse = constructorInfo.GetParameters();
                var objs = new List<object>();
                foreach (var parameterInfo in paramse)
                {
                    var realType =
                            _assemblies.Select(p => p.ExportedTypes.First(t => t.IsInterface == false && parameterInfo.ParameterType.IsAssignableFrom(t)))
                            .First();
                    var tmp = GetInstance(realType);
                    objs.Add(tmp);
                }

                var instance = Activator.CreateInstance(realInstanceType, objs.ToArray());
                return instance;
            }
            else
            {
                var instance = Activator.CreateInstance(realInstanceType);
                return instance;
            }

            return null;
        }

        private static void LoadAssembly()
        {
            _assemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] dllFiles = Directory.GetFiles(path, "*.dll");
            foreach (var item in dllFiles)
            {
                var tmp = Assembly.LoadFile(item);
                _assemblies.Add(tmp);
            }
        }
    }
}
