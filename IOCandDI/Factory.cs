using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IOCandDI.Service;

namespace IOCandDI
{
    /// <summary>
    /// Factory
    /// </summary>
    public static class Factory
    {
        private static List<Assembly> _assemblies;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object GetInstance(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the instance with instance constructor parameters.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object GetInstance(Type type, List<object> parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the instance automatic injection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object GetInstanceAutoInjection(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the assembly.
        /// </summary>
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
