using Autofac;
using EmployeeListApp.Services;

namespace EmployeeListApp.DependencyInjection
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
        }
    }
}
