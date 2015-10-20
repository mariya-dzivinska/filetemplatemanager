using Autofac;
using Bussiness.Default;

namespace Bussiness
{
	public class BussinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ProjectService>()
				.As<IProjectService>()
				.InstancePerLifetimeScope();
		}
	}
}
