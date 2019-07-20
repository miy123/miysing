using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace miysing.Helper
{
    public static class AssemblyExtensions
    {
        public static List<Assembly> GetReferencedAssemblyList(this Assembly assembly)
        {
            var assemblies = new List<Assembly>();
            assembly
                .GetReferencedAssemblies()
                .ToList()
                .ForEach(x => assemblies.Add(Assembly.Load(x)));

            return assemblies;
        }
    }
}
