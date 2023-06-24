using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task_1.Scripts
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        private readonly Dictionary<Type, object> _dictionary = new();

        public void Register(Type type, object obj) => _dictionary.Add(type, obj);

        public void Remove(Type type) => _dictionary.Remove(type);

        public object Get(Type type)
        {
            if (_dictionary.TryGetValue(type, out var t))
            {
                return t;
            }
            
            Debug.LogError("Service Locator: Type not found");

            return null;
        }
    }
}