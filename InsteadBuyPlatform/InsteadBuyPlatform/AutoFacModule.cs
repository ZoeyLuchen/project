using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using InsteadBuyPlatform.IRepository;

namespace InsteadBuyPlatform
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly[] ass = new Assembly[] { Assembly.Load("InsteadBuyPlatform.Repository") };
            builder.RegisterAssemblyTypes(ass).Where(type=>!type.IsInterface && typeof(IAutofacBase).IsAssignableFrom(type))
                .AsImplementedInterfaces().PropertiesAutowired();
        }
    }
}
