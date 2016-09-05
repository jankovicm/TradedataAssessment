using System;
using Autofac;
using Tradedataassessment.Model;
using TradedataAssessment.Data;

namespace TradedataAssessment.Init.Modules
{
    internal class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentException("builder");

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<TradedataEntities>().AsSelf().InstancePerLifetimeScope();
        }
    }
}