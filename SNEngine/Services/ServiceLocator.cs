using System;
using System.Collections.Generic;

namespace SNEngine.Services
{
    public sealed class ServiceLocator
    {
        private static Dictionary<Type, IService> _services;

        public ServiceLocator()
        {
            _services = new Dictionary<Type, IService>();
        }

        public void Initialize()
        {
            IService[] services =
            {
                new DialogueService()
            };

            foreach (var service in services)
            {
                service.Initialize();

                _services.Add(service.GetType(), service);
            }


        }

        internal T Get<T>() where T : IService
        {
            return (T)_services[typeof(T)];
        }
    }
}
