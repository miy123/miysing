using Microsoft.Extensions.DependencyInjection;
using miysing.Helper;
using System;
using System.Linq;
using System.Reflection;

namespace miysing.Web
{
    public static class RegisterExtension
    {
        /// <summary>
        /// 註冊所有ITypeRegistrar中的介面實作
        /// </summary>
        /// <param name="services">Ioc容器</param>
        public static void RegisterType(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .GetReferencedAssemblyList()
                .SelectMany(x => x.GetExportedTypes().Where(y => typeof(ITypeRegistrar).IsAssignableFrom(y) && !y.IsInterface))
                .Select(p => (ITypeRegistrar)Activator.CreateInstance(p))
                .ToList()
                .ForEach(x => x.RegisterTypes(services));
        }
    }
}
