﻿using Autofac;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;

namespace KSociety.Base.Srv.Host.Shared.Bindings
{
    /// <summary>
    /// The UnitOfWork module for Autofac.
    /// </summary>
    /// <typeparam name="TContext">TContext is DatabaseContext</typeparam>
    public class UnitOfWork<TContext> : Module where TContext : DatabaseContext
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Infra.Shared.Class.UnitOfWork<TContext>>().As<IDatabaseUnitOfWork>();
        }
    }
}