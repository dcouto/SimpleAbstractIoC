using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace SimpleAbstractIoC.Web.IoC.Unity
{
    public class UnityDependencyResolverWrapper : IDependencyResolverWrapper
    {
        public IDependencyResolver DependencyResolver { get; internal set; }
        private readonly UnityContainer _container = new UnityContainer();

        public UnityDependencyResolverWrapper()
        {
            DependencyResolver = new UnityDependencyResolver(_container);
        }

        public object GetService(Type serviceType)
        {
            return DependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            yield return DependencyResolver.GetServices(serviceType);
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }
    }
}