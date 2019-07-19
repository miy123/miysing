using Microsoft.Extensions.DependencyInjection;
using miysing.Helper;
using System;
using System.Linq;
using System.Reflection;

namespace miysing.Repository
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterTypes(IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(x => x != typeof(Repository<>))
                .Where(x => x.IsAssignableToGenericType(typeof(IRepository<>)) && !x.IsInterface)
                .ToList()
                .ForEach(type => services.AddScoped(type.GetInterfaces().Where(x => !x.IsGenericType).First(), type));
        }
    }
}
