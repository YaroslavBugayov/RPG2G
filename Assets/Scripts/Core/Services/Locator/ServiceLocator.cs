using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Services.Locator
{
    public class ServiceLocator : MonoBehaviour, IServiceLocator
    {
        private Dictionary<object, object> _services;

        public void Initialize()
        {
            _services = new Dictionary<object, object>();
        }

        public void AddService(Type interfaceOfService, object realizationOfInterface) => 
            _services.Add(interfaceOfService, realizationOfInterface);

        public T GetService<T>() where T : IService
        {
            try
            {
                return (T)_services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("Запрашиваемый сервис не зарегистрирован!");
            }
        }
    }
}