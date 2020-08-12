using Autofac;
using Autofac.Integration.Mvc;
using ComplainMSDAL;
using ComplainMSDAL.CoreRepositories;
using ComplainMSModels;
using ComplainMSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ComplainMS.Configuration
{
    public class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ComplainDBContext>().InstancePerRequest();

           

            builder.RegisterType<LoginRepository>().As<ILoginRepository>();
            builder.RegisterType<ComplainRepository>().As<IComplainRepository>();


            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<ComplainService>().As<IComplainService>();

            //builder.RegisterGeneric(typeof(Repository<>))
            //.As(typeof(IRepository<>));


            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}