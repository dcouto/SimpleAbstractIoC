using System.Web.Mvc;

namespace SimpleAbstractIoC.Web.IoC
{
    public interface IDependencyResolverWrapper : IDependencyResolver
    {
        IDependencyResolver DependencyResolver { get; }
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
    }
}
