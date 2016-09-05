using System;
using System.Linq;
using Autofac;
using TradedataAssessment.Service.Interfaces;

namespace TradedataAssessment.Init.Modules
{
    internal class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentException("builder");
            var assembly = typeof(IService<>).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IService<>)) && !t.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}