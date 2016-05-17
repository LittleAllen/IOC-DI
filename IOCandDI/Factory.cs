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
            //// 載入dll檔
            LoadAssembly();

            //// 預防傳進來的Type為Interface，所以要取實際實作的型別
            var realInstanceType =
                _assemblies.Select(
                    p => p.ExportedTypes.First(
                        t => t.IsInterface == false &&
                             type.IsAssignableFrom(t))).First();
            var instance = Activator.CreateInstance(realInstanceType);
            return instance;
        }

        /// <summary>
        /// Gets the instance with instance constructor parameters.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object GetInstance(Type type, List<object> parameters)
        {
            LoadAssembly();
            var realInstanceType =
                _assemblies.Select(
                    p => p.ExportedTypes.First(
                        t => t.IsInterface == false &&
                             type.IsAssignableFrom(t))).First();
            var instance = Activator.CreateInstance(realInstanceType, parameters.ToArray());
            return instance;
        }

        /// <summary>
        /// Gets the instance automatic injection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object GetInstanceAutoInjection(Type type)
        {
            LoadAssembly();
            var realInstanceType =
                _assemblies.Select(
                    p => p.ExportedTypes.First(
                        t => t.IsInterface == false &&
                             type.IsAssignableFrom(t))).First();

            //// 取得Type的所有建構式清單
            var constructorInfos =
                realInstanceType.GetConstructors();

            //// 從建構式清單中取出有傳入參數的建構式
            var constructorInfo =
                constructorInfos.FirstOrDefault(p => p.GetParameters().Count() > 0);
            if (constructorInfo != null)
            {
                var objs = new List<object>();

                ////取出建構式的傳入參數
                var parameters = constructorInfo.GetParameters();

                ////產生建構式所需要的參數實體
                foreach (var parameter in parameters)
                {
                    var realParameterType =
                        _assemblies.Select(
                            p => p.ExportedTypes.First(
                                t => t.IsInterface == false &&
                                     parameter.ParameterType.IsAssignableFrom(t))).First();

                    var parameterInstance =
                        GetInstanceAutoInjection(realParameterType);
                    objs.Add(parameterInstance);
                }

                var instance = Activator.CreateInstance(realInstanceType, objs.ToArray());
                return instance;
            }
            else
            {
                var instance = Activator.CreateInstance(realInstanceType);
                return instance;
            }
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
