using System.Web.Mvc;
using SimpleAbstractIoC.Web.IoC;
using SimpleAbstractIoC.Web.Security.Managers;
using Sitecore.Pipelines;
using Sitecore.Reflection;

namespace SimpleAbstractIoC.Web.Pipelines.Initialize
{
    public class CustomDependencyResolverSetter
    {
        public string DependencyResolverWrapper { get; set; }

        public void Process(PipelineArgs args)
        {
            var resolver = (IDependencyResolverWrapper)ReflectionUtil.CreateObject(DependencyResolverWrapper, new object[0]);

            resolver.RegisterType<ISecurityManager, SecurityManager>();

            DependencyResolver.SetResolver(resolver.DependencyResolver);
        }
    }
}