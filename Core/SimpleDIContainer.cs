using System;
using System.Collections.Generic;

namespace AATM.Core
{
    public class SimpleDIContainer
    {
        private readonly Dictionary<Type, object> container = new Dictionary<Type, object>();

        public void Register(Type serviceType, object implementation)
        {
            container[serviceType] = implementation;
        }

        public object Resolve(Type serviceType)
        {
            if (container.ContainsKey(serviceType))
            {
                return container[serviceType];
            }
            // Return Nothing if the service is not found.
            return null;
        }

    }
}