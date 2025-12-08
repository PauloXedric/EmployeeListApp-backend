using Autofac;
using EmployeeListApp.Repositories;

namespace EmployeeListApp.DependencyInjection
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
        }
    }
}
