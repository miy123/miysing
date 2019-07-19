using Microsoft.Extensions.DependencyInjection;
using System;

namespace miysing.Helper
{
    public interface ITypeRegistrar
    {
        void RegisterTypes(IServiceCollection service);
    }
}
