using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miysing.Helper
{
    public static class AssignableExtensions
    {
        /// <summary>
        /// Determines whether the genericType is assignable from givenType taking into account
        /// generic definitions
        /// </summary>
        /// <param name="givenType">目標物件</param>
        /// <param name="genericType">欲檢查的 generic type</param>
        /// <returns>yes or no</returns>
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            if (givenType == null || genericType == null)
            {
                return false;
            }

            return givenType == genericType
              || givenType.MapsToGenericTypeDefinition(genericType)
              || givenType.HasInterfaceThatMapsToGenericTypeDefinition(genericType)
              || givenType.BaseType.IsAssignableToGenericType(genericType);
        }

        /// <summary>
        /// 是否目標物件繼承的介面包含特定 generic type
        /// </summary>
        /// <param name="givenType">目標物件</param>
        /// <param name="genericType">欲檢查的 generic type</param>
        /// <returns>是/否</returns>
        private static bool HasInterfaceThatMapsToGenericTypeDefinition(this Type givenType, Type genericType)
        {
            return givenType
              .GetInterfaces()
              .Where(it => it.IsGenericType)
              .Any(it => it.GetGenericTypeDefinition() == genericType);
        }

        /// <summary>
        /// 是否對應到 Generic Type 的定義
        /// </summary>
        /// <param name="givenType">目標物件</param>
        /// <param name="genericType">欲檢查的 generic type</param>
        /// <returns>是/否</returns>
        private static bool MapsToGenericTypeDefinition(this Type givenType, Type genericType)
        {
            return genericType.IsGenericTypeDefinition
              && givenType.IsGenericType
              && givenType.GetGenericTypeDefinition() == genericType;
        }
    }
}
